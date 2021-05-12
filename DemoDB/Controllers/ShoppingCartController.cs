using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;

namespace DemoDB.Controllers
{
    public class ShoppingCartController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                //return RedirectToAction("ShowCart", "ShoppingCart");
                return View("EmptyCart");
            }
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }

        //Action tạo mới giỏ hàng
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        //Action thêm product vào giỏ hàng
        public ActionResult AddToCart(int id)
        {
            var _pro = database.Products.SingleOrDefault(s => s.ProductID == id); //lấy pro theo ID
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        //Cập nhật số lượng sản phẩm và tính lại tổng tiền
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        //Xóa dòng sản phẩm trong giỏ hàng
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CarItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        //Lấy tổng số lượng sản phẩm có trong giỏ hàng
        public PartialViewResult BagCart()
        {
            int total_quantity_iten = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                total_quantity_iten = cart.Total_quantity();
            }
            ViewBag.QuantityCart = total_quantity_iten;
            return PartialView("BagCart");
        }
    }
}
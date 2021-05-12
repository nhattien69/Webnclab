using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDB.Models
{
    public class CartItem
    {
        public Product _product { get; set; }
        public int _quantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        //Lấy sản phẩm bỏ vào giỏ hàng
        public void Add_Product_Cart(Product _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ProductID == _pro.ProductID);
            
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _product = _pro,
                    _quantity = _quan
                });
            }
            else
            {
                item._quantity += _quan;
            }
        }

        //Tính tổng số lượng trong giỏ hàng
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }

        //Tính thành tiền cho mỗi dòng sản phẩm trong giỏ hàng
        public decimal Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.Price);
            return (decimal)total;
        }

        //Cập nhật lại số lượng sản phẩm ở mỗi dòng sản phẩm khi khách hàng muốn đặt mua thêm
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._product.ProductID == id);
            if (item != null)
            {
                item._quantity = _new_quan;
            }
        }

        //Xóa sản phẩm trong giỏ hàng
        public void Remove_CarItem(int id)
        {
            items.RemoveAll(s => s._product.ProductID == id);
        }

        //Xóa giỏ hàng sau khi khách hàng thực hiện thanh toán
        public void ClearCart()
        {
            items.Clear();
        }
    }
}
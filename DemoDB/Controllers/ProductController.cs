using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;

namespace DemoDB.Controllers
{
    public class ProductController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(database.Products.ToList());
        }

        public ActionResult Create()
        {
            Product pro = new Product();
            return View(pro);
        }

        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = database.Categories.ToList<Category>();
            return PartialView(se_cate);
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                if(pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = "~/Content/images/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
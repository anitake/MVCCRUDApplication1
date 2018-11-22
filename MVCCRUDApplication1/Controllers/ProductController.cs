using MVCCRUDApplication1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MVCCRUDApplication1.Models;

namespace MVCCRUDApplication1.Controllers
{
    public class ProductController : Controller
    {
        private const int PAGE_NUMBER = 7;

        private IProductRepository fProductReposity;

        public ProductController()
        {
            this.fProductReposity = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index(int page=1)
        {
            int currentPage = page < 1 ? 1 : page;

            var products = fProductReposity.GetAll().OrderBy(x=>x.ProductID);

            var result = products.ToPagedList(currentPage,PAGE_NUMBER);

            return View(result);
        }

        public ActionResult GetImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "bad-grades.png";
            }
            return File("~/ProductImages/" + fileName, "image/jpeg|png|gif");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.category = fProductReposity.GetAll()
                .GroupBy(x => x.CategoryID).Select(y => y.Key).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            fProductReposity.Create(product);

            return RedirectToAction("Index");
        }




    }
}
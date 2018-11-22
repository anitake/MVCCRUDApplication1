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
            ViewBag.category = fProductReposity.GetCategoryIds();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            fProductReposity.Create(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.category = fProductReposity.GetCategoryIds();

            Product result = fProductReposity.GetById(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            fProductReposity.Update(product);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result =fProductReposity.GetById(id);

            fProductReposity.Delete(result);

            return RedirectToAction("Index");

        }




    }
}
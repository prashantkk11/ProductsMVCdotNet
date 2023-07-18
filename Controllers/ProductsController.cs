using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsMVC.Models;

namespace ProductsMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            List<Product> list = Product.GetAllProducts();
            return View(list);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return NotFound();
            Product product = Product.GetSingleProduct(id);
            return View(product);
            //return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Product obj)
        {
            try
            {
                Product.Create(obj);
                ViewBag.Message = "Success!";
                return View();
               // return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
                //return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = Product.GetSingleProduct(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Product obj)
        {
            try
            {
                Product.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product prod = Product.GetSingleProduct(id);
            return View(prod);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Product.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

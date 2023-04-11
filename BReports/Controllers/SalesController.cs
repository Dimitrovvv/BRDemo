using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BReports.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleRepository saleService;
        private readonly IProductRepository productService;
        private readonly ICategoryRepository categoryService;
        public SalesController(ISaleRepository saleService, IProductRepository productService, ICategoryRepository categoryService)
        {
            this.saleService = saleService;
            this.productService = productService;
            this.categoryService = categoryService;
        }
   
        // GET: SalesController
        public IActionResult Index()
        {
            var productsData = productService.GetAll();
            var categoriesData = categoryService.GetAll();
            var model = new SaleViewModel();
            model.ProductsList = new List<SelectListItem>();
            model.CategoriesList = new List<SelectListItem>();

            foreach (var product in productsData)
            {
                model.ProductsList.Add(new SelectListItem { Text = product.Name, Value = product.Id.ToString()});
            }
            foreach (var category in categoriesData)
            {
                model.CategoriesList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });

            }
            if (model.ProductsList == null)
            { 
            
            }
            return View(model);


        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

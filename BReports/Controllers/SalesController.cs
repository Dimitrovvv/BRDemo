using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        public IActionResult Index()
        {
            var sales = this.saleService.GetAll();
            var model = new SaleViewModelList
            {
                List = GetSaleViewModel(sales)

            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SaleViewModel();
            var categoriesData = categoryService.GetAll();
            var productsData = productService.GetAll();

            model.ProductsList = new List<SelectListItem>();
            model.CategoriesList = new List<SelectListItem>();

            foreach (var category in categoriesData)
            {
                model.CategoriesList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            foreach (var product in productsData)
            {
                model.ProductsList.Add(new SelectListItem { Text = product.Name, Value = product.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SaleViewModel sale)
        {
            this.saleService.Create(GetSaleDataModel(sale));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int saleId)
        {
            var sale = this.saleService.GetById(saleId);
            var model = GetSaleViewModel(sale);
            if (sale == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SaleViewModel sale)
        {
            this.saleService.Update(GetSaleDataModel(sale));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.saleService.Delete(id);
            return RedirectToAction("Index");
        }
        private Sale GetSaleDataModel(SaleViewModel sale)
        {
            return new Sale
            {
                Id = sale.Id,
                Product = sale.Product,
                SoldBy = sale.User,
                CustomerId = sale.CustomerId,
                Description = sale.Description,
                Amount = sale.Amount,
                SaleDate = DateTime.Now
            };
        }

        private SaleViewModel GetSaleViewModel(Sale sale)
        {

            return new SaleViewModel
            {
                Id = sale.Id,
                Product = sale.Product,
                User = sale.SoldBy,
                CustomerId = sale.CustomerId,
                Description = sale.Description,
                Amount = sale.Amount,
                SaleDate = sale.SaleDate
            };
        }
        private List<SaleViewModel> GetSaleViewModel(List<Sale> source)
        {
            var sales = new List<SaleViewModel>();

            foreach (var element in source)
            {
                sales.Add(GetSaleViewModel(element));
            }
            return sales;
        }
    }
}

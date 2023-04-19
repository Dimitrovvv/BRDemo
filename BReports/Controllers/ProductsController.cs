using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace BReports.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository productService;
        private readonly ICategoryRepository categoryService;

        public ProductsController(IProductRepository productService, ICategoryRepository categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = this.productService.GetAll();

            var model = new ProductViewModelList
            {
                List = GetProductViewModel(products)

            };
            return View(model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoriesData = categoryService.GetAll();
            var model = new ProductViewModel();
            model.CategoriesList = new List<SelectListItem>();

            foreach (var category in categoriesData)
            {
                model.CategoriesList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            this.productService.Create(GetProductDataModel(product));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var productDataModel = this.productService.GetById(productId);

            return View(GetProductViewModel(productDataModel));
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            Product productDataModel = this.productService.GetById(model.Id);

            if (productDataModel == null)
            {
                return NotFound();
            }

            ProductViewModel productViewModel = GetProductViewModel(productDataModel);
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.productService.Delete(id);
            return RedirectToAction("Index");

        }

        private Product GetProductDataModel(ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }

        private ProductViewModel GetProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
        private List<ProductViewModel> GetProductViewModel(List<Product> source)
        {
            var products = new List<ProductViewModel>();

            foreach (var element in source)
            {
                products.Add(GetProductViewModel(element));
            }

            return products;
        }
    }
}

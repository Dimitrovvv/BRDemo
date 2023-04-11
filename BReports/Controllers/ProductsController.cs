using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           
        public IActionResult Details(int productid)
        {
            var productDataModel = this.productService.GetById(productid);
            return View(GetProductViewModel(productDataModel));
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
            var categoriesData = categoryService.GetAll();
            var model = new ProductViewModel();
            model.CategoriesList = new List<SelectListItem>();

            foreach (var category in categoriesData)
            {
                model.CategoriesList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
          
            this.productService.Create(GetProductDataModel(product));
            return RedirectToAction("Index");
        }

        public IActionResult Edit(ProductViewModel product)
        {
            this.productService.Update(GetProductDataModel(product));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productId)
        {
            this.productService.Delete(productId);
            return Ok();
   
        }

        private Product GetProductDataModel(ProductViewModel product)
        {
         

            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                

            };
        }

        private ProductViewModel GetProductViewModel(Product product)
        {
          
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
            
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

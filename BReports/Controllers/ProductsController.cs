using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BReports.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
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
            return View();
        }

        [HttpPost]
         public IActionResult Create(ProductViewModel product)
        {
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
                Name = product.Name
            };
        }

        private ProductViewModel GetProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name
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

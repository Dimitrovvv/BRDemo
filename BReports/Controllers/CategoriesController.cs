using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BReports.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryService;

        public CategoriesController(ICategoryRepository categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = this.categoryService.GetAll();
            return View(GetCategoryViewModel(categories));
        }

        public IActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel category)
        {
            this.categoryService.Create(GetCategoryDataModel(category));
            return RedirectToAction("Index");

        }

        public IActionResult Edit(CategoryViewModel category)
        {
            this.categoryService.Update(GetCategoryDataModel(category));
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            this.categoryService.Delete(Id);
            return RedirectToAction("Index");

        }

        private Category GetCategoryDataModel(CategoryViewModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        private CategoryViewModel GetCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        private List<CategoryViewModel> GetCategoryViewModel(List<Category> source)
        {
            var categories = new List<CategoryViewModel>();

            foreach (var c in source)
            {
                categories.Add(GetCategoryViewModel(c));
            }
            return categories;
        }
    }
}

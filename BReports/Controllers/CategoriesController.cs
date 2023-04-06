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

        // GET: CategoriesController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
   
        public IActionResult Create(Category category)
        {
            this.categoryService.Create(category);
            return RedirectToAction("Index");
            
        }

        // GET: CategoriesController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
   
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesController/Delete/5
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

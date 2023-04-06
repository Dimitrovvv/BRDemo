using BReports.Data;
using BReports.Models.DBModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BReports.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Category> GetAll()
        {
            return this.db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return this.db.Categories.FirstOrDefault(x => x.Id == id);

        }

        public int GetCount()
        {
            return this.db.Categories.Count();
        }
        public void Create(Category category)
        {
            this.db.Categories.Add(category);
            this.db.SaveChanges();
        }
        public void Update(Category category)
        {
            var categoryToUpdate = this.db.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryToUpdate == null) { return; }

            categoryToUpdate.Name = category.Name;

            this.db.SaveChanges();

        }
        public void Delete(int id)
        {
            var categoryToDelete = this.db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryToDelete == null) { return; }

            categoryToDelete.IsDeleted = true;
            this.db.SaveChanges();
        }

        public void Create(IActionResult actionResult)
        {
            throw new System.NotImplementedException();
        }
    }
}

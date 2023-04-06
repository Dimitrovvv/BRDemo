using BReports.Data;
using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BReports.Services
{
    public class ProductService : IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Product> GetAll()
        {
            return this.db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return this.db.Products.FirstOrDefault(x => x.Id == id);

        }

        public int GetCount()
        {
            return this.db.Products.Count();
        }
        public void Create(Product product)
        {
            this.db.Products.Add(product);
            this.db.SaveChanges();
        }
        public void Update(Product product)
        {
            var productToUpdate = this.db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate == null) { return; }

            productToUpdate.Name = product.Name;

            this.db.SaveChanges();

        }
        public void Delete(int id)
        {
            var productToDelete = this.db.Products.FirstOrDefault(x => x.Id == id);
            if (productToDelete == null) { return; }

            productToDelete.IsDeleted = true;
            this.db.SaveChanges();
        }

        public void changeSomething(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}

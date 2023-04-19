using BReports.Data;
using BReports.Models.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace BReports.Services
{
    public class SaleService : ISaleRepository
    {
        private readonly ApplicationDbContext db;

        public SaleService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Sale> GetAll()
        {
            return this.db.Sales
                .Where(sale => !sale.IsDeleted)
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public Sale GetById(int id)
        {
            return this.db.Sales.FirstOrDefault(x => x.Id == id);

        }

        public int GetCount()
        {
            return this.db.Sales.Count();
        }
        public void Create(Sale sale)
        {
            this.db.Sales.Add(sale);
            this.db.SaveChanges();
        }
        public void Update(Sale sale)
        {
            var saleToUpdate = this.db.Sales.FirstOrDefault(x => x.Id == sale.Id);
            if (saleToUpdate == null) { return; }

          //  saleToUpdate.Name = Sale.Name;

            this.db.SaveChanges();

        }
        public void Delete(int id)
        {
            var saleToDelete = this.db.Sales.FirstOrDefault(x => x.Id == id);
            if (saleToDelete == null) { return; }

            saleToDelete.IsDeleted = true;
            this.db.SaveChanges();
        }

    }
}

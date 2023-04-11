using BReports.Data;
using BReports.Models.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace BReports.Services
{
    public class LocationService : ILocationRepository
    {
        private readonly ApplicationDbContext db;

        public LocationService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Location> GetAll()
        {
            return this.db.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return this.db.Locations.FirstOrDefault(x => x.Id == id);

        }

        public int GetCount()
        {
            return this.db.Categories.Count();
        }
        public void Create(Location location)
        {
            this.db.Locations.Add(location);
            this.db.SaveChanges();
        }
        public void Update(Location location)
        {
            var locationToUpdate = this.db.Locations.FirstOrDefault(x => x.Id == location.Id);
            if (locationToUpdate == null) { return; }

            locationToUpdate.Name = location.Name;

            this.db.SaveChanges();

        }
        public void Delete(int id)
        {
            var locationToDelete = this.db.Locations.FirstOrDefault(x => x.Id == id);
            if (locationToDelete == null) { return; }

            locationToDelete.IsDeleted = true;
            this.db.SaveChanges();
        }
    }
}

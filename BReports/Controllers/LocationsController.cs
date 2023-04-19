using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BReports.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepository locationService;

        public LocationsController(ILocationRepository locationService)
        {
            this.locationService = locationService;
        }

        public IActionResult Index()
        {
            var locations = this.locationService.GetAll();
            return View(GetLocationViewModel(locations));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            this.locationService.Create(location);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
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

        private Location GetLocationDataModel(LocationViewModel location)
        {
            return new Location
            {
                Id = location.Id,
                Name = location.Name,
                Region = location.Region
            };
        }

        private LocationViewModel GetLocationViewModel(Location location)
        {
            return new LocationViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Region = location.Region
            };
        }
        private List<LocationViewModel> GetLocationViewModel(List<Location> source)
        {
            var locations = new List<LocationViewModel>();

            foreach (var loc in source)
            {
                locations.Add(GetLocationViewModel(loc));
            }
            return locations;
        }
    }
}

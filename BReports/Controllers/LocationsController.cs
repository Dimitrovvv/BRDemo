using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = this.locationService.GetById(id);
            var model = GetLocationViewModel(location);
            if (location == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(LocationViewModel location)
        {
            this.locationService.Update(GetLocationDataModel(location));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            this.locationService.Delete(id);
            return RedirectToAction("Index");
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

using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using BReports.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BReports.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILocationRepository locationService;


        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILocationRepository locationService
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.locationService = locationService;

        }

        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BankId = model.BankId,
                    Location = model.Location,
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User Id {id} cannot be found";
                return View("Not found");
            }
            var model = new UserViewModel

            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BankId = user.BankId,
                Location = user.Location,
            };
            model.LocationList = new List<SelectListItem>();
            var locationsData = locationService.GetAll();
            foreach (var location in locationsData)
            {
                model.LocationList.Add(new SelectListItem { Text = location.Name, Value = location.Name });
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User Id {model.Id} cannot be found";
                return View("Not found");
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.BankId = model.BankId;
                user.Location = model.Location;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                return View(model);
            };


        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User Id {id} cannot be found";
                return View("NotFound");
            }
            else
            {

                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                { ModelState.AddModelError("", error.Description); }
                return View("Index");
            }
        }
    }
}



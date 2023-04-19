using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BReports.Controllers
{
    public class RolesController : Controller
    {
        public readonly RoleManager<IdentityRole> roleManager;


        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Name,
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {id} cannot be found";
                return View("NotFound");
            }
            var model = new RoleViewModel
            {
                Name = role.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.Name;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role Id {id} cannot be found";
                return View("NotFound");
            }
            else
            {

                var result = await roleManager.DeleteAsync(role);
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

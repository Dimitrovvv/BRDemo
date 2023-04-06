using BReports.Models.DBModels;
using BReports.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BReports.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
                    
        }

        // GET: ApplicationUsersController
        public ActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        // GET: ApplicationUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsersController/Create
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BankId = model.BankId,
                    Location = model.Location,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                { 
                await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(model); 
        }

        // GET: ApplicationUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: ApplicationUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationUsersController/Delete/5
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
    }
}

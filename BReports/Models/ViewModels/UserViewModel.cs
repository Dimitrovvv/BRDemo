using BReports.Models.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BReports.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BankId { get; set; }
        public Location Location { get; set; }
        public IdentityRole Role { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public string ConfirmPassword { get; set; }
        public List<SelectListItem> LocationList { get; set; }
    }
}

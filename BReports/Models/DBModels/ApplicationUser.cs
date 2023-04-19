using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BReports.Models.DBModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BankId { get; set; }
        public Location Location { get; set; }
        public IdentityRole Role { get; set; }
        public ICollection<Sale> Sales { get; set; }



    }
}

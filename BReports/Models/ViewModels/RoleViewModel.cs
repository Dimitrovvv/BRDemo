using System.ComponentModel.DataAnnotations;

namespace BReports.Models.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; } 
        [Required]
        public string Name { get; set; }
    }
}

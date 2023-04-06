using System.ComponentModel.DataAnnotations;

namespace BReports.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted   { get; set; }
    }
}

using BReports.Models.DBModels;

namespace BReports.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}

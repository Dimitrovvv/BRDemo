using BReports.Models.DBModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BReports.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }

    }
}

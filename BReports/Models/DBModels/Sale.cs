using System;

namespace BReports.Models.DBModels
{
    public class Sale
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; } 
        public string CustomerId { get; set; } 
        public DateTime SaleDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}

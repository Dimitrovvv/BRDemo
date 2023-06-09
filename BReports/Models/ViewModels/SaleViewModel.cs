﻿using BReports.Models.DBModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BReports.Models.ViewModels
{
    public class SaleViewModel
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
        public List<SelectListItem> ProductsList {get; set;}
        public List<SelectListItem> CategoriesList { get; set;}
    }
}

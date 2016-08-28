using OnlineShop.DAL.Entities;
using OnlineShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static OnlineShop.Controllers.SortProduct;

namespace OnlineShop.Models
{
    public class CatalogViewModel
    {
        public CatalogViewModel()
        {
            DiscountRange = new List<CheckBox>() { new CheckBox { Text = "0-10%" }, new CheckBox { Text = "10-30%" }, new CheckBox { Text = "30-50%" }, new CheckBox { Text = "50-75%" } };
            PriceRange = new List<CheckBox>() { new CheckBox { Text = "0-100 грн" }, new CheckBox { Text = "100-250 грн" }, new CheckBox { Text = "250-500 грн" }, new CheckBox { Text = "500-750 грн" }, new CheckBox { Text = "750-1000 грн" }, new CheckBox { Text = "Больше 1000 грн" } };
            Popularity = new List<CheckBox>() { new CheckBox { Text = "2.png" }, new CheckBox { Text = "3.png" }, new CheckBox { Text = "4.png" }, new CheckBox { Text = "5.png" } };

        }
        
        public IEnumerable<ProductViewModel> Products{get;set;}
        public List<CheckBox> DiscountRange { get; set; }
        public List<CheckBox> PriceRange { get; set; }
        public List<CheckBox> Colors { get; set; }
        public List<CheckBox> Popularity { get; set; }
        public string Subcategory { get; set; }
        public string Catalog{ get; set; }
        public Sort Sort { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    
}
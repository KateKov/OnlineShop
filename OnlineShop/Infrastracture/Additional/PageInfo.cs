using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Helpers
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // number of current page
        public int PageSize { get; set; } // number of objects on the page
        public int TotalItems { get; set; } // total number of objects
        public int TotalPages  // total number of pages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
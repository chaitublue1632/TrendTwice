using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendTwice.Models
{
    
    public class Sale
    {
        public int ListingId { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Size {get;set;}
    }
}
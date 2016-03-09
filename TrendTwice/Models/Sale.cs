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
        public string Description { get; set; }
        public string DressName { get; set; }
        public double Price { get; set; }
        public string Size {get;set;}
        public string Condition { get; set; }
        public string Category { get; set; }
        public List<string> PhotoUrls { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendTwice.Models;

namespace TrendTwice.ViewModels
{
    public class CheckoutViewModel
    {
        public Sale saleItem { get; set; }
        public Checkout checkout { get; set; }
    }
}
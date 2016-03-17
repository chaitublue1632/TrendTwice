using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendTwice.Models;

namespace TrendTwice.ViewModels
{
    public class CheckoutViewModel
    {
        public Sale SaleItem { get; set; }
        public Checkout Checkout { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
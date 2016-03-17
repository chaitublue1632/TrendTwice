using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendTwice.ViewModels
{
    public class CreditCard
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVC { get; set; }
        public double Amount { get; set; }
    }
}
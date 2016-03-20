using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrendTwice.ViewModels
{
    public class CreditCard
    {
        [Required(ErrorMessage = "Name is required")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Card Number is required")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration is required")]
        public string Expiration { get; set; }

        [Required(ErrorMessage = "CVC is required")]
        public string CVC { get; set; }

        [Required(ErrorMessage = "Amount is required")]    
        [Range(0.0, double.MaxValue, ErrorMessage = "Please enter a valid amount")]
        public double Amount { get; set; }
    }
}
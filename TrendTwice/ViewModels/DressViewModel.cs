using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendTwice.Models;

namespace TrendTwice.ViewModels
{
    public class DressViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int? FabricId { get; set; }
        public int ConditionId { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter valid price")]
        public double Price { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Please enter number between 1 and 10")]
        public int PieceCount { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Name { get; set; }
        public List<string> SelectedPhotos { get; set; }
        public string Brand { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Conditions { get; set; }
        public IEnumerable<SelectListItem> Fabrics { get; set; }
        public IEnumerable<SelectListItem> Sizes { get; set; }
        public IEnumerable<SelectListItem> Photos { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
    }
}
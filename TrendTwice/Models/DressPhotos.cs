using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TrendTwice.Models
{
    [Table("Photos")]
    public partial class DressPhotos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DressId { get; set; }
        
        [Required]
        public string Path { get; set; }

        public bool Active { get; set; }

        public virtual Dress Dress { get; set; }
    }
}

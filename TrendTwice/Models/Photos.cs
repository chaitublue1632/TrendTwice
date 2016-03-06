namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photos
    {

        public int DressId { get; set; }

        public string Path { get; set; }

        public bool? Active { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }

        public virtual Dress Dress { get; set; }

    }
}

namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DressFabric")]
    public partial class DressFabric
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FabricId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

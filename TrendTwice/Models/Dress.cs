namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dress")]
    public partial class Dress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dress()
        {
            Listings = new HashSet<Listings>();
            Photos = new HashSet<Photos>();
        }

        public int Id { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        public int? FabricId { get; set; }

        public int ConditionId { get; set; }

        public int PieceCount { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public virtual DressCategories DressCategories { get; set; }

        public virtual DressColors DressColors { get; set; }

        public virtual DressConditions DressConditions { get; set; }

        public virtual DressFabric DressFabric { get; set; }

        public virtual DressSize DressSize { get; set; }

        //public virtual DressPhotos DressPhotos { get; set; }
        //public virtual Photos Photos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Listings> Listings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photos> Photos { get; set; }
    }
}

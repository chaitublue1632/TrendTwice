namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Listings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Listings()
        {
            Checkout = new HashSet<Checkout>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ListingId { get; set; }

        public int UserId { get; set; }

        public int DressId { get; set; }

        public int Status { get; set; }

        public bool Active { get; set; }

        public int? Likes { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string SessionId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Checkout> Checkout { get; set; }

        public virtual Dress Dress { get; set; }

        public virtual Users Users { get; set; }
    }
}

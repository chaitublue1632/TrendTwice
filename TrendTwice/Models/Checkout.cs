namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Checkout")]
    public partial class Checkout
    {
        public int CheckoutId { get; set; }

        public int ListingId { get; set; }

        public int UserId { get; set; }

        public int StatusId { get; set; }

        public bool Finished { get; set; }

        public DateTime TimeStamp { get; set; }

        public virtual Listings Listings { get; set; }
    }
}

namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WishList")]
    public partial class WishList
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ListingId { get; set; }

        public DateTime AddedDate { get; set; }

        public virtual Users Users { get; set; }
    }
}

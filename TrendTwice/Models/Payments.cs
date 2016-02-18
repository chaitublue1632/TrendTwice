namespace TrendTwice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payments
    {
        [Key]
        [Column(Order = 0)]
        public int PaymentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CheckoutId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentType { get; set; }

        [Key]
        [Column(Order = 3)]
        public double Amount { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool HasFailed { get; set; }

        public DateTime? DateStamp { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ListingId { get; set; }
    }
}

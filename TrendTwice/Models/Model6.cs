namespace TrendTwice.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbModel : DbContext
    {
        public dbModel()
            : base("name=Model")
        {
        }

        public virtual DbSet<Checkout> Checkout { get; set; }
        public virtual DbSet<Dress> Dress { get; set; }
        public virtual DbSet<DressCategories> DressCategories { get; set; }
        public virtual DbSet<DressColors> DressColors { get; set; }
        public virtual DbSet<DressConditions> DressConditions { get; set; }
        public virtual DbSet<DressFabric> DressFabric { get; set; }
        //public virtual DbSet<DressPhotos> DressPhotos { get; set; }
        public virtual DbSet<DressSize> DressSize { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Listings> Listings { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Dress>()
                .HasMany(e => e.Listings)                
                .WithRequired(e => e.Dress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DressCategories>()
                .HasMany(e => e.Dress)
                .WithRequired(e => e.DressCategories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DressColors>()
                .HasMany(e => e.Dress)
                .WithRequired(e => e.DressColors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DressConditions>()
                .HasMany(e => e.Dress)
                .WithRequired(e => e.DressConditions)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Photos>()
            //    .HasMany(e => e.Dress)
            //    .WithRequired(e => e.Photos)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<DressFabric>()
                .HasMany(e => e.Dress)
                .WithRequired(e => e.DressFabric)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DressSize>()
                .HasMany(e => e.Dress)
                .WithRequired(e => e.DressSize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Listings>()
                .HasMany(e => e.Checkout)
                .WithRequired(e => e.Listings)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Listings)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.WishList)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}

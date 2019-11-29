namespace Mr_Travel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);
        }
    }
}

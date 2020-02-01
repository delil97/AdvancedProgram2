namespace LabbAsignment2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgencyModel : DbContext
    {
        public AgencyModel()
            : base("name=AgencyModelll")
        {
        }

        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Destination> Destination { get; set; }
        public virtual DbSet<Travelers> Travelers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>()
                .Property(e => e.eMail)
                .IsUnicode(false);

            modelBuilder.Entity<Agency>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Travelers>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}

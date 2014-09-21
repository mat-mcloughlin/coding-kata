namespace CodingKata.Core
{
    using System.Data.Entity;

    public class CodingKataContext : DbContext
    {
        public CodingKataContext()
            : base("ConnectionString")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Colour> Colours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PeopleMap());
            modelBuilder.Configurations.Add(new ColourMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
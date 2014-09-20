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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PeopleMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
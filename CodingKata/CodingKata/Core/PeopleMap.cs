namespace CodingKata.Core
{
    using System.Data.Entity.ModelConfiguration;

    public class PeopleMap : EntityTypeConfiguration<Person>
    {
        public PeopleMap()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.Id).HasColumnName("PersonId");

            this.HasMany(p => p.FavouriteColours)
                .WithMany()
                .Map(k =>
                {
                    k.MapLeftKey("PersonId");
                    k.MapRightKey("ColourId");
                    k.ToTable("FavouriteColours");
                });
        }
    }
}
namespace CodingKata.Core
{
    using System.Data.Entity.ModelConfiguration;

    public class ColourMap : EntityTypeConfiguration<Colour>
    {
        public ColourMap()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.Id).HasColumnName("ColourId");
        }
    }
}
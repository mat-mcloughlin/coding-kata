namespace CodingKata.Core
{
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAuthorised { get; set; }

        public bool IsValid { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<Colour> FavouriteColours { get; set; }
    }
}
namespace CodingKata.Dto
{
    using System.Collections.Generic;
    using System.Linq;

    using CodingKata.Core;

    public class PersonDto
    {
        public PersonDto(int id, string firstName, string lastName, bool isAuthorised, bool isEnabled, IEnumerable<Colour> favouriteColours)
        {
            this.Id = id;
            this.IsEnabled = isEnabled;
            this.Name = firstName + " " + lastName;
            this.IsAuthorised = isAuthorised;

            if (favouriteColours != null)
            {
                this.Colours = favouriteColours
                    .Select(c => c.Id)
                    .ToList();
            }
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public bool IsAuthorised { get; private set; }

        public bool IsEnabled { get; private set; }

        public ICollection<int> Colours { get; set; }
    }
}
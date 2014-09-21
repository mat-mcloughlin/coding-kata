namespace CodingKata.Dto
{
    using System.Collections.Generic;
    using System.Linq;

    using CodingKata.Core;
    using CodingKata.Extensions;

    public class PersonBriefDto
    {
        public PersonBriefDto(int id, string firstName, string lastName, bool isAuthorised, bool isEnabled, IEnumerable<Colour> favouriteColours)
        {
            this.Id = id;
            this.IsEnabled = isEnabled;
            this.Name = firstName + " " + lastName;
            this.IsAuthorised = isAuthorised;

            if (favouriteColours != null)
            {
                this.Colours = string.Join(", ", favouriteColours.Select(c => c.Name));
            }
        }

        public string Colours { get; private set; }

        public int Id { get; private set; }

        public bool IsEnabled { get; private set; }

        public bool IsAuthorised { get; private set; }

        public bool IsPalindrome
        {
            get
            {
                return this.Name.IsPalindrome();
            }
        }

        public string Name { get; private set; }
    }
}
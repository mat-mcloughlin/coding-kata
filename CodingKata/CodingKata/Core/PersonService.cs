namespace CodingKata.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CodingKata.Dto;

    public class PersonService : IPersonService
    {
        private readonly CodingKataContext context;

        public PersonService(CodingKataContext context)
        {
            this.context = context;
        }

        public IEnumerable<PersonBriefDto> GetAllBrief()
        {
            return this.context.People.Include("FavouriteColours")
                .ToList()
                .Select(p => new PersonBriefDto(p.Id, p.FirstName, p.LastName, p.IsAuthorised, p.IsEnabled, p.FavouriteColours));
        }

        public PersonDto Get(int id)
        {
            var person = this.context.People.Include("FavouriteColours")
                 .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                return new PersonDto(
                    person.Id,
                    person.FirstName,
                    person.LastName,
                    person.IsAuthorised,
                    person.IsEnabled,
                    person.FavouriteColours);
            }

            return null;
        }

        public bool Update(PersonDto personDto)
        {
            var person = this.context.People.Include("FavouriteColours")
                 .FirstOrDefault(p => p.Id == personDto.Id);

            if (person == null)
            {
                return false;
            }

            person.IsAuthorised = personDto.IsAuthorised;
            person.IsEnabled = personDto.IsEnabled;

            person.FavouriteColours.Clear();
            var colours = this.context.Colours.Where(c => personDto.Colours.Contains(c.Id));
            foreach (var colour in colours)
            {
                person.FavouriteColours.Add(colour);
            }

            this.context.SaveChanges();
            return true;
        }
    }
}
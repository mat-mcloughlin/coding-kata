namespace CodingKata.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using CodingKata.Core;
    using CodingKata.Dto;

    public class PersonController : ApiController
    {
        private readonly CodingKataContext context;

        public PersonController(CodingKataContext context)
        {
            this.context = context;
        }

        public IEnumerable<PersonBrief> GetAll()
        {
            return this.context.People
                .ToList()
                .Select(p => new PersonBrief(p.FirstName, p.LastName, p.IsAuthorised, p.IsEnabled));
        }
    }
}

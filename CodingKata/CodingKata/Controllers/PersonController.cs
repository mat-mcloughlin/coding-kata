namespace CodingKata.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using CodingKata.Core;

    public class PersonController : ApiController
    {
        private readonly CodingKataContext context;

        public PersonController(CodingKataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return this.context.People.ToList();
        }
    }
}

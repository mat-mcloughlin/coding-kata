namespace CodingKata.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;

    using CodingKata.Core;
    using CodingKata.Dto;

    public class PersonController : ApiController
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        public IEnumerable<PersonBriefDto> GetAll()
        {
            return this.personService.GetAllBrief();
        }

        public PersonDto Get(int id)
        {
            return this.personService.Get(id);
        }

        public HttpStatusCode Post([FromBody]PersonDto personDto)
        {
            if (personDto == null)
            {
                return HttpStatusCode.BadRequest;
            }

            return this.personService.Update(personDto) ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        }
    }
}

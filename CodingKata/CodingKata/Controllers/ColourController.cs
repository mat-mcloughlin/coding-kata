namespace CodingKata.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using CodingKata.Core;
    using CodingKata.Dto;

    public class ColourController : ApiController
    {
        private readonly IColourService colourService;

        public ColourController(IColourService colourService)
        {
            this.colourService = colourService;
        }

        public IEnumerable<ColourDto> GetAll()
        {
            return this.colourService.GetAll();
        }
    }
}

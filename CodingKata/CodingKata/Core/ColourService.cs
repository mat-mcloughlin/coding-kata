namespace CodingKata.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using CodingKata.Dto;

    public class ColourService : IColourService
    {
        private readonly CodingKataContext context;

        public ColourService(CodingKataContext context)
        {
            this.context = context;
        }

        public IEnumerable<ColourDto> GetAll()
        {
            return this.context.Colours
                .ToList()
                .Select(p => new ColourDto(p.Id, p.Name));
        }
    }
}
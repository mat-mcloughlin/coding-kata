namespace CodingKata.Core
{
    using System.Collections.Generic;

    using CodingKata.Dto;

    public interface IColourService
    {
        IEnumerable<ColourDto> GetAll();
    }
}
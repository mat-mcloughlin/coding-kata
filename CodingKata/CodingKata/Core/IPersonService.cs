namespace CodingKata.Core
{
    using System.Collections.Generic;

    using CodingKata.Dto;

    public interface IPersonService
    {
        IEnumerable<PersonBriefDto> GetAllBrief();

        PersonDto Get(int id);

        bool Update(PersonDto personDto);
    }
}
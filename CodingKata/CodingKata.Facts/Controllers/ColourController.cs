namespace CodingKata.Facts.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using CodingKata.Controllers;
    using CodingKata.Core;
    using CodingKata.Dto;

    using Moq;

    using Xunit;
    using Xunit.Should;

    public class ColourControllerFacts
    {
        [Fact]
        public void GetAllReturnsAListOfUsers()
        {
            var mockService = new Mock<IColourService>();
            mockService.Setup(s => s.GetAll()).Returns(new List<ColourDto> 
            { 
                new ColourDto(1, "Red"), 
                new ColourDto(2, "Blue"),
                new ColourDto(3, "Green"), 
            });

            var controller = new ColourController(mockService.Object);

            var actual = controller.GetAll().ToList();

            actual.Count().ShouldBe(3);
            actual.First().Id.ShouldBe(1);
            actual.First().Name.ShouldBe("Red");
        }
    }
}

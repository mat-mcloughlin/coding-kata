namespace CodingKata.Facts.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using CodingKata.Controllers;
    using CodingKata.Core;
    using CodingKata.Dto;

    using Moq;

    using Xunit;
    using Xunit.Should;

    public class PersonControllerFacts
    {
        [Fact]
        public void GetAllReturnsAListOfUsers()
        {
            var mockService = new Mock<IPersonService>();
            mockService.Setup(s => s.GetAllBrief()).Returns(new List<PersonBriefDto> 
            { 
                new PersonBriefDto(1, "Willis", "Tibbs", true, true, this.GetMockColours()), 
                new PersonBriefDto(2, "Sharon", "Halt", true, true, this.GetMockColours()),
                new PersonBriefDto(3, "Patrick", "Kerr", true, true, this.GetMockColours()), 
            });

            var controller = new PersonController(mockService.Object);

            var actual = controller.GetAll().ToList();

            actual.Count().ShouldBe(3);
            actual.First().Id.ShouldBe(1);
            actual.First().Name.ShouldBe("Willis Tibbs");
            actual.First().IsEnabled.ShouldBeTrue();
            actual.First().IsAuthorised.ShouldBeTrue();
            actual.First().Colours.ShouldBe("Red, Green, Blue");
        }

        [Fact]
        public void GetReturnsUserForId()
        {
            var mockService = new Mock<IPersonService>();
            mockService.Setup(s => s.Get(It.IsAny<int>()))
                .Returns(new PersonDto(1, "Willis", "Tibbs", true, true, this.GetMockColours()));

            var controller = new PersonController(mockService.Object);

            var actual = controller.Get(1);

            actual.Id.ShouldBe(1);
            actual.Name.ShouldBe("Willis Tibbs");
            actual.IsEnabled.ShouldBeTrue();
            actual.IsAuthorised.ShouldBeTrue();
            actual.Colours.Count.ShouldBe(3);
            actual.Colours.First().ShouldBe(1);
        }

        [Fact]
        public void PostReturnBadRequestWhenNullPersonDtoPosted()
        {
            var mockService = new Mock<IPersonService>();
         
            var controller = new PersonController(mockService.Object);

            var actual = controller.Post(null);

            actual.ShouldBe(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public void PostReturnNotFoundWhenCantFindItem()
        {
            var mockService = new Mock<IPersonService>();

            var controller = new PersonController(mockService.Object);

            var actual = controller.Post(new PersonDto(1, "Willis", "Tibbs", true, false, new List<Colour>()));

            mockService.Verify(s => s.Update(It.IsAny<PersonDto>()), Times.Once);

            actual.ShouldBe(HttpStatusCode.NotFound);
        }

        public List<Colour> GetMockColours()
        {
            return new List<Colour>
            {
                new Colour { Id = 1,  Name = "Red" }, 
                new Colour { Id = 2,  Name = "Green" }, 
                new Colour { Id = 3,  Name = "Blue" }
            };
        }
    }
}

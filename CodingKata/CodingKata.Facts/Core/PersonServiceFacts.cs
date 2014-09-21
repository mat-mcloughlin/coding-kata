namespace CodingKata.Facts.Core
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using CodingKata.Core;

    using Moq;

    using Xunit;
    using Xunit.Should;

    public class PersonServiceFacts
    {
        [Fact]
        public void GetAllBriefReturnsACollection()
        {
            var mockContext = this.GetMockContext();
            var service = new PersonService(mockContext.Object);

            var actual = service.GetAllBrief().ToList();

            actual.Count().ShouldBe(3);
            actual.First().Name.ShouldBe("Willis Tibbs");
            actual.First().IsEnabled.ShouldBeTrue();
            actual.First().IsAuthorised.ShouldBeTrue();
            actual.First().Colours.ShouldBe("Red, Green, Blue");
        }

        [Fact]
        public void GetReturnById()
        {
            var mockContext = this.GetMockContext();
            var service = new PersonService(mockContext.Object);

            var actual = service.Get(1);

            actual.Name.ShouldBe("Willis Tibbs");
            actual.IsEnabled.ShouldBeTrue();
            actual.IsAuthorised.ShouldBeTrue();
            actual.Colours.Count.ShouldBe(3);
        }

        public Mock<CodingKataContext> GetMockContext()
        {
            var data = new List<Person> 
            { 
                new Person { Id = 1, FirstName = "Willis", LastName = "Tibbs", IsEnabled = true, IsAuthorised = true, FavouriteColours = this.GetMockColours() }, 
                new Person { Id = 2, FirstName = "Sharon", LastName = "Halt", IsEnabled = true, IsAuthorised = true, FavouriteColours = this.GetMockColours() }, 
                new Person { Id = 3, FirstName = "Patrick", LastName = "Kerr", IsEnabled = true, IsAuthorised = true, FavouriteColours = this.GetMockColours() }, 
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockDbSet.Setup(m => m.Include(It.IsAny<string>())).Returns(mockDbSet.Object);

            var mockContext = new Mock<CodingKataContext>();
            mockContext.Setup(c => c.People).Returns(mockDbSet.Object);

            return mockContext;
        }

        public List<Colour> GetMockColours()
        {
            return new List<Colour>
            {
                new Colour { Name = "Red" }, 
                new Colour { Name = "Green" }, 
                new Colour { Name = "Blue" }
            };
        }
    }
}
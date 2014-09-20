namespace CodingKata.Facts.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using CodingKata.Controllers;
    using CodingKata.Core;

    using Moq;

    using Xunit;
    using Xunit.Should;

    public class PersonControllerFacts
    {
        [Fact]
        public void GetAllReturnsAListOfUsers()
        {
            var mockContext = this.GetMockContext();
            var controller = new PersonController(mockContext.Object);

            var actual = controller.GetAll().ToList();

            actual.Count().ShouldBe(3);
            actual.First().FirstName.ShouldBe("BBB");
        }

        public Mock<CodingKataContext> GetMockContext()
        {
            var data = new List<Person> 
            { 
                new Person { FirstName = "BBB" }, 
                new Person { FirstName = "ZZZ" }, 
                new Person { FirstName = "AAA" }, 
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CodingKataContext>();
            mockContext.Setup(c => c.People).Returns(mockDbSet.Object);

            return mockContext;
        }
    }
}

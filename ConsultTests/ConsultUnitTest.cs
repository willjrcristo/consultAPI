using ConsultAPI.Models;
using ConsultAPI.Validations;
//using Microsoft.EntityFrameworkCore;
//using Moq;
using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using TestSupport.EfHelpers;
using Xunit;

namespace ConsultTests
{
    public class ConsultTest
    {
        [Fact]
        public void ErrorIfStartAfterFinish()
        {
            var consult = new Consult
            {
                id = 9999999,
                consultStartAt = new DateTime(2019, 6, 18, 13, 0, 0),
                consultFinishAt = new DateTime(2019, 6, 18, 12, 0, 0)
            };

            var consultValidation = new ConsultValidation();

            var ex = Assert.Throws<Exception>(() => consultValidation.validStartBeforeFinish(consult));
            Assert.Equal(ex.Message, "The consult can not end before you start");            
        }

        [Fact]
        public void SucessIfStartBeforeFinish()
        {
            var consult = new Consult
            {
                id = 9999999,
                consultStartAt = new DateTime(2019, 6, 18, 12, 0, 0),
                consultFinishAt = new DateTime(2019, 6, 18, 13, 0, 0)
            };

            var consultValidation = new ConsultValidation();

            var idReturned = consultValidation.validStartBeforeFinish(consult);
            Assert.Equal(consult.id, idReturned);
        }

        /*
        [Fact]
        public void validStartBeforeFinishAfter()
        {
            string conn = "Server=localhost;Database=dbConsult;Trusted_Connection=True;MultipleActiveResultSets=true";

            //ConsultRepository repository = new ConsultRepository(conn);

            /*DbContextOptions<ConsultRepository> options = new DbContextOptionsBuilder<ConsultRepository>()
                .UseInMemoryDatabase(databaseName:"Test")
                .EnableSensitiveDataLogging()
                .Options;*

            var context = CreateDbContext();

            var consultPreExistent = new Consult
            {
                id = 0,
                consultStartAt = new DateTime(2019, 6, 18, 12, 0, 0),
                consultFinishAt = new DateTime(2019, 6, 18, 13, 0, 0)
            };

            var consultStartBeforeFinishAfter = new Consult
            {
                id = 0,
                consultStartAt = new DateTime(2019, 6, 18, 11, 30, 0),
                consultFinishAt = new DateTime(2019, 6, 18, 13, 30, 0)
            };

            var consultValidation = new ConsultValidation();

            var ex = Assert.Throws<Exception>(() => consultValidation.validRange(null, consultStartBeforeFinishAfter, consultPreExistent));
            Assert.Equal(ex.Message, "Range unavailable!");
        }

        private Mock<ConsultRepository> CreateDbContext()
        {
            var Consults = GetFakeData().AsQueryable();

            var dbSet = new Mock<DbSet<Consult>>();
            dbSet.As<IQueryable<Consult>>().Setup(m => m.Provider).Returns(Consults.Provider);
            dbSet.As<IQueryable<Consult>>().Setup(m => m.Expression).Returns(Consults.Expression);
            dbSet.As<IQueryable<Consult>>().Setup(m => m.ElementType).Returns(Consults.ElementType);
            dbSet.As<IQueryable<Consult>>().Setup(m => m.GetEnumerator()).Returns(Consults.GetEnumerator());

            var context = new Mock<ConsultRepository>();
            context.Setup(c => c.Consults).Returns(dbSet.Object);
            return context;
        }

        private IEnumerable<Consult> GetFakeData()
        {
            var i = 1;
            var consults = A.ListOf<Consult>(26);
            consults.ForEach(x => x.Id = i++);
            return consults.Select(_ => _);
        }
        */
    }
}

using ConsultAPI.Models;
using ConsultAPI.Validations;
using System;
using Xunit;

namespace ConsultTests
{
    public class ConsultTest
    {
        [Fact]
        public void StartBeforeEnd()
        {
            var consult = new Consult
            {
                id = 9999999,
                consultStartAt = new DateTime(2019, 6, 18, 13, 0, 0),
                consultFinishAt = new DateTime(2019, 6, 18, 12, 0, 0)
            };

            var consultValidation = new ConsultValidation(consult);

            var ex = Assert.Throws<Exception>(() => consultValidation.allValidations());
            Assert.Equal(ex.Message, "The consult can not end before you start");            
        }
    }
}

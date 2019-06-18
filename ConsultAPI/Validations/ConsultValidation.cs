using ConsultAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultAPI.Validations
{
    public class ConsultValidation
    {
        private Consult _consult;
        public ConsultValidation(Consult consult)
        {
            _consult = consult;
        }

        public void validStartBeforeEnd()
        {
            if (_consult.consultFinishAt < _consult.consultStartAt)
            {
                throw new Exception("The consult can not end before you start");
            }
        }

        public void allValidations()
        {
            validStartBeforeEnd();
        }
    }
}

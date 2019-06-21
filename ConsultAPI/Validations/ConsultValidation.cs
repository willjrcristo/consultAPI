using ConsultAPI.Models;
using System;
using System.Linq;

namespace ConsultAPI.Validations
{
    public class ConsultValidation
    {

        public ConsultValidation()
        {            
        }

        public int validStartBeforeFinish(Consult consult)
        {
            if (consult.consultFinishAt < consult.consultStartAt)
            {
                throw new Exception("The consult can not end before you start");
            }

            return consult.id;
        }

        public void validRange(ConsultRepository repository, Consult consult, Consult preExistent)
        {
            if (preExistent != null)
            {
                repository.Consults.Add(preExistent);
            }
            var consults = repository.Consults
                .Where(
                    _preExistent => (
                        consult.consultStartAt >= _preExistent.consultStartAt &&
                        consult.consultStartAt <= _preExistent.consultFinishAt
                    ) || (
                        consult.consultFinishAt >= _preExistent.consultStartAt &&
                        consult.consultFinishAt <= _preExistent.consultFinishAt
                    ) || (
                        _preExistent.consultStartAt >= consult.consultStartAt &&
                        _preExistent.consultStartAt <= consult.consultFinishAt
                    ) || (
                        _preExistent.consultFinishAt >= consult.consultStartAt &&
                        _preExistent.consultFinishAt <= consult.consultFinishAt
                    )
                )
                .ToList();

            if (consults.Count > 0)
            {
                throw new Exception("Range unavailable!");
            }

            Console.WriteLine("Range ok!");
        }

        public void allValidations(ConsultRepository repository, Consult consult, Consult preExistent)
        {
            validStartBeforeFinish(consult);
            validRange(repository, consult, preExistent);
        }
    }
}

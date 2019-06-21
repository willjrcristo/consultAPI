using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultAPI.Models;
using ConsultAPI.Validations;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly ConsultRepository _repository;
        public ConsultController(ConsultRepository context)
        {
            _repository = context;            
        }

        //GET: api/Consult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consult>>> GetConsults()
        {
            var response = await _repository.Consults.ToListAsync();
            return response;
        }

        // GET: api/Consult/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Consult>> GetConsultId(int id)
        {

            var consult = await _repository.Consults.FindAsync(id);

            if (consult == null)
            {
                return NotFound();
            }

            return consult;
        }

        // POST: api/Consult
        [HttpPost]
        public async Task<ActionResult<Consult>> PostConsult(Consult consult)
        {
            var consultValidation = new ConsultValidation();

            consultValidation.allValidations(_repository, consult, null);

            Console.WriteLine("Adding row...");

            _repository.Consults.Add(consult);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsultId), new { id = consult.id }, consult);
        }
        
    }
}

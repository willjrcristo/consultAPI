﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultAPI.Models;
using ConsultAPI.Validations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly ConsultRepository _context;
        public ConsultController(ConsultRepository context)
        {
            _context = context;

            /*if (_context.Consults.Count() == 0)
            {
                _context.Consults.Add(new Consult { id = 1, patient_name = "Will" });
                _context.SaveChanges();
            }*/
        }

        //GET: api/Consult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consult>>> GetConsults()
        {
            return await _context.Consults.ToListAsync();
        }

        // GET: api/Consult/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Consult>> GetConsultId(int id)
        {

            var consult = await _context.Consults.FindAsync(id);

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
            var consultValidation = new ConsultValidation(consult);

            consultValidation.allValidations();

            _context.Consults.Add(consult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsultId), new { id = consult.id }, consult);
        }
        /*
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}

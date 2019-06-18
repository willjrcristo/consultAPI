using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultAPI.Models
{
    public class ConsultRepository: DbContext
    {
        public ConsultRepository(DbContextOptions<ConsultRepository> options): base(options)
        {

        }
        public DbSet<Consult> Consults { get; set; }
    }
}

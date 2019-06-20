using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace ConsultAPI.Models
{

    public class ConsultRepository: DbContext
    {
        private string _connectionString;

        public ConsultRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ConsultRepository(DbContextOptions<ConsultRepository> options): base(options)
        {

        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder
                    .UseSqlServer(_connectionString)
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }

        public DbSet<Consult> Consults { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;

namespace ConsultAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            /*
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "root";
            builder.InitialCatalog = "dbConsult";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                connection.Open();
                StringBuilder qryConsults = new StringBuilder();
                qryConsults.Append("SELECT TOP 20 ");
                qryConsults.Append("c.id as ConsultId");
                qryConsults.Append(",c.consultStartAt as startAt,");
                qryConsults.Append(",c.consultFinishtAt as finishAt,");
                qryConsults.Append(",c.consultNotes as notes,");
                qryConsults.Append(",c.patientName as notes,");
                qryConsults.Append("FROM [dbConsult].[Consults] c ");
                String sql = qryConsults.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var line = "id:{0}" +
                                "\nstartAt:{1}" +
                                "\nfinishAt:{2}" +
                                "\nnotes:{3}" +
                                "\npatientName:{4}" +
                                "\npatientBornIn:{5}";

                            Console.WriteLine(
                                line, 
                                reader.GetString(0), 
                                reader.GetString(1), 
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                            );

                        }
                    }
                }
            }
            */
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

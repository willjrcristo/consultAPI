using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultAPI.Models
{
    public class Consult
    {
        public int id { get; set; }
        public System.DateTime consultStartAt { get; set; }
        public System.DateTime consultFinishAt { get; set; }
        public string consultNotes { get; set; }
        public string patientName { get; set; }
        public System.DateTime patientBornIn { get; set; }
    }
}

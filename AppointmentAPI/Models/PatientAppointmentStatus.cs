using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PatientAppointmentStatus
    {
        public int PatientAppointmentId { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
    }
}

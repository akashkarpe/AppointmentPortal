using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PatientAppointments
    {
        public int Id { get; set; }
        public int AppointmentDateSlotId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhoneNo { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
    }
}

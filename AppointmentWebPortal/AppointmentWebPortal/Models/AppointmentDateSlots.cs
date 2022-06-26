using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppointmentDateSlots
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PatientAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentSlotId { get; set; }
        public int FromTime { get; set; }
        public int ToTime { get; set; }
        public bool IsBooked { get; set; }
    }
}

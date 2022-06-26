using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentWebPortal.Models
{
    public class AppointmentSlotData
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhoneNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientAppointmentId { get; set; }
        public int AppointmentSlotId { get; set; }
        public int FromTime { get; set; }
        public int ToTime { get; set; }
        public bool IsBooked { get; set; }
        public int  Status { get; set; }
    }
}
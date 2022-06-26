using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentWebPortal.Models
{
    public class LoginResponse
    {
        public int DoctorId { get; set; }
        public string Token { get; set; }
    }
}
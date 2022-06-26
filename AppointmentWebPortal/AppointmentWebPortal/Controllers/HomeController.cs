using AppointmentWeb.Utility;
using AppointmentWebPortal.Utility;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppointmentWebPortal.Controllers
{
    [CheckLogin]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = Convert.ToString(TempData["Message"]);
            APIHelper aPIHelper = new APIHelper();
            var Response = aPIHelper.GetData(Constants.GetDoctorsList );
            List<User> users = JsonConvert.DeserializeObject<List<User>>(Convert.ToString(Response.Data));
            ViewBag.UserList = users;
            return View();
        }

        public ActionResult BookAppointment(int DoctorId)
        {
            APIHelper aPIHelper = new APIHelper();
            var Response = aPIHelper.GetData(Constants.GetAppointmentList+ "?DoctorId="+ DoctorId);
            List<AppointmentDateSlots> apptSlots = JsonConvert.DeserializeObject<List<AppointmentDateSlots>>(Convert.ToString(Response.Data));
            ViewBag.AppointmentDateSlots = apptSlots;
            PatientAppointments patientAppointments = new PatientAppointments();
            return View(patientAppointments);
        }

        [HttpPost]
        public ActionResult BookAppointment(PatientAppointments patientAppointments)
        {
            APIHelper aPIHelper = new APIHelper();
            patientAppointments.Status = 1;
            var Response = aPIHelper.PostData(Constants.BookAppointment, patientAppointments);
            if (Response.Status == "F")
            {
                TempData.Add("Message", "Error in Saving Appointment");
            }
            else
            {
                TempData.Add("Message", "Appointment Booked Successfully");
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
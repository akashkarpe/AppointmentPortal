using AppointmentWeb.Utility;
using AppointmentWebPortal.Models;
using AppointmentWebPortal.Utility;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppointmentWebPortal.Controllers
{
    [Authentication]
    [Authorize]
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            APIHelper aPIHelper = new APIHelper();
            SessionUtility sessionUtility = new SessionUtility();
            var DoctorId = ((LoginResponse)sessionUtility.GetValueFromSession(Constants.LoginResponse)).DoctorId;
            var Response = aPIHelper.GetData(Constants.DoctorAllSlots+ "?DoctorId=" + DoctorId);
            List<AppointmentSlotData> myslots = JsonConvert.DeserializeObject<List<AppointmentSlotData>>(Convert.ToString(Response.Data));
            ViewBag.MySlots = myslots;
            ViewBag.TotalAppointmets = myslots.Count();
            ViewBag.BookedAppointmets = myslots.Where(w => w.IsBooked == true).ToList().Count();
            ViewBag.UpcommingAppointmets = myslots.Where(w => w.AppointmentDate >= DateTime.Today).OrderBy(w=>w.AppointmentDate).ToList().Count();
            return View();
        }

        public ActionResult MyAppointments()
        {
            APIHelper aPIHelper = new APIHelper();
            SessionUtility sessionUtility = new SessionUtility();
            var DoctorId = ((LoginResponse)sessionUtility.GetValueFromSession(Constants.LoginResponse)).DoctorId;
            var Response = aPIHelper.GetData(Constants.DoctorAllSlots + "?DoctorId=" + DoctorId);
            if (Response.Status == "S")
            {
                List<AppointmentSlotData> myslots = JsonConvert.DeserializeObject<List<AppointmentSlotData>>(Convert.ToString(Response.Data));

                var upcommingBookedSlots = myslots.Where(w => w.IsBooked == true && w.AppointmentDate >= DateTime.Today).ToList();
                ViewBag.MySlots = upcommingBookedSlots;
                ViewBag.UpcommingAppointmets = upcommingBookedSlots.Count();
            }
            return View();
        }
        public ActionResult RejectAppointment(int Id)
        {
            PatientAppointmentStatus patientAppointmentStatus = new PatientAppointmentStatus();
            patientAppointmentStatus.PatientAppointmentId = Id;
            patientAppointmentStatus.Status = 3;
            return View(patientAppointmentStatus);
        }

        [HttpPost]
        public ActionResult AcceptAppointmet(int AppId,int Status)
        {
            PatientAppointmentStatus patientAppointmentStatus = new PatientAppointmentStatus();
            patientAppointmentStatus.PatientAppointmentId = AppId;
            patientAppointmentStatus.Status = Status;
            patientAppointmentStatus.Comment = "";
            APIHelper aPIHelper = new APIHelper();
            var Response = aPIHelper.PostData(Constants.UpdateAppointmentStatus , patientAppointmentStatus);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RejectAppointment(PatientAppointmentStatus patientAppointmentStatus)
        {
            APIHelper aPIHelper = new APIHelper();
            var Response = aPIHelper.PostData(Constants.UpdateAppointmentStatus, patientAppointmentStatus);
            return View();
        }

        public void AddSlots(string date)
        {
            APIHelper aPIHelper = new APIHelper();
            ReqAddSlot reqAddSlot = new ReqAddSlot();
            SessionUtility sessionUtility = new SessionUtility();

            reqAddSlot.DoctorId = ((LoginResponse)sessionUtility.GetValueFromSession(Constants.LoginResponse)).DoctorId;
            reqAddSlot.SlotDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var Response = aPIHelper.PostData(Constants.InsertDateSlots, reqAddSlot);
        }
    }
}
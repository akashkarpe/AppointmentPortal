using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Controllers
{

    public class PublicController : ApiController
    {
        PublicMaster publicMaster;
        public PublicController()
        {
            publicMaster = new PublicMaster();
        }


        [HttpGet]
        public Response GetDoctorsList()
        {
            Response res = new Response();
            try
            {
                var result = publicMaster.GetDoctorsList();
                res.Data = result;
                res.Status = "S";
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpGet]
        public Response GetAppointmentList(int DoctorId)
        {
            Response res = new Response();
            try
            {
                DoctorMaster doctorMaster = new DoctorMaster();
                var result = doctorMaster.GetDoctorsAllSlots(DoctorId);
                res.Data = result;
                res.Status = "S";
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        public Response BookAppointment([FromBody]PatientAppointments patientAppointments)
        {
            Response res = new Response();
            try
            {
                var result = publicMaster.BookAppointment(patientAppointments);
                res.Data = result;
                res.Status = "S";
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }
    }
}

using AppointmentAPI.Filter;
using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppointmentAPI.Controllers
{
    [CustomAuthFilter]
    public class DoctorController : ApiController
    {
        DoctorMaster doctorMaster;
        public DoctorController()
        {
            doctorMaster = new DoctorMaster();
        }

        [HttpGet]
        public Response GetAllMySlots(int DoctorId)
        {
            Response res = new Response();
            try
            {
                var result = doctorMaster.GetAllMySlots(DoctorId);
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
        public Response GetDoctorsBookedSlots(int DoctorId)
        {
            Response res = new Response();
            try
            {
                var result = doctorMaster.GetDoctorsBookedSlots(DoctorId);
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
        public Response InsertDateSlots([FromBody] ReqAddSlot reqAddSlot)
        {
            Response res = new Response();
            try
            {
                var result = doctorMaster.InsertDateSlots(reqAddSlot);
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
        public Response UpdateAppointmentStatus([FromBody] PatientAppointmentStatus patientAppointmentStatus)
        {
            Response res = new Response();
            try
            {
                var result = doctorMaster.UpdateAppointmentStatus(patientAppointmentStatus);
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

using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DoctorMaster
    {
        DoctorDBAccess doctordbAccess;
        public DoctorMaster()
        {
            doctordbAccess = new DoctorDBAccess();
        }

        private List<AppointmentSlotData> ConvertDTtoListApptData(DataTable dtData)
        {
            List<AppointmentSlotData> appointmentSlotDatas = new List<AppointmentSlotData>();
            try
            {
                appointmentSlotDatas = (from DataRow dr in dtData.Rows
                 select new AppointmentSlotData()
                 {
                     Id = Convert.ToInt32(dr["Id"]),
                     PatientName = Convert.ToString(dr["PatientName"]),
                     PatientEmail = Convert.ToString(dr["PatientEmail"]),
                     PatientPhoneNo = Convert.ToString(dr["PatientPhoneNo"]),
                     AppointmentDate = Convert.ToDateTime(dr["AppointmentDate"]),
                     AppointmentSlotId = Convert.ToInt32(dr["AppointmentSlotId"]),
                     //DoctorId = Convert.ToInt32(dr["DoctorId"]),
                     IsBooked = dr["IsBooked"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsBooked"]),
                     FromTime = Convert.ToInt32(dr["FromTime"]),
                     ToTime = Convert.ToInt32(dr["ToTime"]),
                     DoctorId= Convert.ToInt32(dr["DoctorId"]),
                     Status = dr["Status"] == DBNull.Value ? 0: Convert.ToInt32(dr["Status"]),
                     PatientAppointmentId = dr["PatientAppointmentId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PatientAppointmentId"]),

                 }).ToList();
            }
            catch
            {
                throw;
            }
            return appointmentSlotDatas;
        }

        public List<AppointmentSlotData> GetAllMySlots(int DoctorId)
        {
            List<AppointmentSlotData> appointmentSlotDatas = new List<AppointmentSlotData>();
            try
            {
                var dtapptslots = doctordbAccess.GetDoctorsAllSlots(DoctorId);
                appointmentSlotDatas = ConvertDTtoListApptData(dtapptslots);
            }
            catch
            {
                throw;
            }
            return appointmentSlotDatas;
        }

        public List<AppointmentDateSlots> GetDoctorsAllSlots(int DoctorId)
        {
            List<AppointmentDateSlots> appointmentDateSlots = new List<AppointmentDateSlots>();
            try
            {
                var dtapptslots = doctordbAccess.GetDoctorsAllSlots(DoctorId);
                appointmentDateSlots = (from DataRow dr in dtapptslots.Rows
                                        select new AppointmentDateSlots()
                                        {
                                            Id = Convert.ToInt32(dr["Id"]),
                                            AppointmentDate = Convert.ToDateTime(dr["AppointmentDate"]),
                                            AppointmentSlotId = Convert.ToInt32(dr["AppointmentSlotId"]),
                                            //DoctorId = Convert.ToInt32(dr["DoctorId"]),
                                            IsBooked = dr["IsBooked"]==DBNull.Value ? false:Convert.ToBoolean(dr["IsBooked"]),
                                            FromTime = Convert.ToInt32(dr["FromTime"]),
                                            ToTime = Convert.ToInt32(dr["ToTime"]),
                                            PatientAppointmentId = dr["PatientAppointmentId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PatientAppointmentId"]),
                                            
                                        }).ToList();
            }
            catch
            {
                throw;
            }
            return appointmentDateSlots;
        }

        public List<AppointmentSlotData> GetDoctorsBookedSlots(int DoctorId)
        {
            List<AppointmentSlotData> appointmentDateSlots = new List<AppointmentSlotData>();
            try
            {
                var dtapptslots = doctordbAccess.GetDoctorsBookedSlots(DoctorId);
                appointmentDateSlots = ConvertDTtoListApptData(dtapptslots);
            }
            catch
            {
                throw;
            }
            return appointmentDateSlots;
        }

        public int InsertDateSlots(ReqAddSlot reqAddSlot)
        {
            int result = 0;
            try
            {
                var lstslots = GetSlots();
                List<AppointmentDateSlots> lstAppointmentDateSlots = new List<AppointmentDateSlots>();
                foreach (var slot in lstslots)
                {
                    lstAppointmentDateSlots.Add(new AppointmentDateSlots
                    {
                        AppointmentDate = reqAddSlot.SlotDate,
                        AppointmentSlotId = slot.Id,
                        DoctorId = reqAddSlot.DoctorId,
                        IsBooked = false
                    }); ;
                }

                result = doctordbAccess.InsertDateSlots(lstAppointmentDateSlots);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int UpdateAppointmentStatus(PatientAppointmentStatus patientAppointmentStatus)
        {
            int result = 0;
            try
            {
                result = doctordbAccess.UpdateAppointmentStatus(patientAppointmentStatus);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public List<AppointmentSlots> GetSlots()
        {
            List<AppointmentSlots> appointmentSlots = new List<AppointmentSlots>();
            try
            {
                var dtapptslots = doctordbAccess.GetSlots();
                appointmentSlots = (from DataRow dr in dtapptslots.Rows
                         select new AppointmentSlots()
                         {
                             Id = Convert.ToInt32(dr["Id"]),
                             FromTime = Convert.ToInt32(dr["FromTime"]),
                             ToTime = Convert.ToInt32(dr["ToTime"])
                         }).ToList();
            }
            catch
            {
                throw;
            }
            return appointmentSlots;
        }
    }
}

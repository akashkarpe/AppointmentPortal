using DataAccessLayer.DBHelper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DoctorDBAccess
    {
        private DataAccessLayer.DBHelper.DBHelper dbHelper;
        public DoctorDBAccess()
        {
            dbHelper = new SQLHelper();
        }

        public DataTable GetDoctorsBookedSlots(int DoctorId)
        {
            DataTable result = new DataTable();
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"select p.Id as PatientAppointmentId ,a.Id,a.AppointmentDate ,ast.Id as AppointmentDateSlotId,a.AppointmentDate, PatientEmail ,  PatientName   ,  
                                PatientPhoneNo,Status ,Comment,ast.FromTime,ast.ToTime,a.IsBooked,a.DoctorId,p.Status  from AppointmentDateSlots a inner join AppointmentSlots ast
on a.AppointmentSlotId=ast.Id  left join PatientAppointments p 
                                on a.Id =p.AppointmentDateSlotId
                                where a.DoctorId=@DoctorId and a.IsBooked=1;";
                keyValuePairs.Add("@DoctorId", DoctorId);
                result = dbHelper.GetDataSet(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }



        public DataTable GetDoctorsAllSlots(int DoctorId)
        {
            DataTable result = new DataTable();
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"select p.Id as PatientAppointmentId ,a.Id,a.AppointmentDate ,ast.Id as AppointmentSlotId,a.AppointmentDate, PatientEmail ,  PatientName   ,  
                                PatientPhoneNo,Status ,Comment,ast.FromTime,ast.ToTime,a.IsBooked,a.DoctorId  from AppointmentDateSlots a inner join AppointmentSlots ast
on a.AppointmentSlotId=ast.Id  left join PatientAppointments p 
                                on a.Id =p.AppointmentDateSlotId
                                where a.DoctorId=@DoctorId;";
                keyValuePairs.Add("@DoctorId", DoctorId);
                result = dbHelper.GetDataSet(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public DataTable GetSlots()
        {
            DataTable result = new DataTable();
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"select Id,FromTime,ToTime from AppointmentSlots;";
                result = dbHelper.GetDataSet(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int InsertDateSlots(List<AppointmentDateSlots> appointmentDateSlots)
        {
            int result = 0;
            try
            {
                foreach (var slot in appointmentDateSlots)
                {
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    dbHelper.Query = @"INSERT INTO AppointmentDateSlots(AppointmentDate,DoctorId,AppointmentSlotId,IsBooked)
                                values(@AppointmentDate,@DoctorId,@AppointmentSlotId,@IsBooked);";
                    //keyValuePairs.Add("@Id", user.Id);
                    keyValuePairs.Add("@AppointmentDate", slot.AppointmentDate);
                    keyValuePairs.Add("@DoctorId", slot.DoctorId);
                    keyValuePairs.Add("@AppointmentSlotId", slot.AppointmentSlotId);
                    keyValuePairs.Add("@IsBooked", slot.IsBooked);
                    result = dbHelper.ExecuteNonQuery(keyValuePairs);
                }
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
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"update PatientAppointments set Status=@Status,Comment=@Comment where Id=@Id";
                keyValuePairs.Add("@Id", patientAppointmentStatus.PatientAppointmentId);
                keyValuePairs.Add("@Status", patientAppointmentStatus.Status);
                keyValuePairs.Add("@Comment", patientAppointmentStatus.Comment);
                result = dbHelper.ExecuteNonQuery(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}

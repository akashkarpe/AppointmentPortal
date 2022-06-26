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
    public class PublicDBAccess
    {
        private DataAccessLayer.DBHelper.DBHelper dbHelper;
        public PublicDBAccess()
        {
            dbHelper = new SQLHelper();
        }

        public DataTable GetDoctorList()
        {
            DataTable result = new DataTable();
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"select Id,Name,Email,PhoneNo,CreatedOn from Users;";
                result = dbHelper.GetDataSet(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int BookAppointment(PatientAppointments patientAppointments)
        {
            int result = 0;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"INSERT INTO PatientAppointments(AppointmentDateSlotId,PatientEmail,PatientName,PatientPhoneNo,Status,Comment)
                                values(@AppointmentDateSlotId,@PatientEmail,@PatientName,@PatientPhoneNo,@Status,@Comment);
update AppointmentDateSlots set IsBooked=1 where Id=@AppointmentDateSlotId";
                //keyValuePairs.Add("@Id", user.Id);
                keyValuePairs.Add("@AppointmentDateSlotId", patientAppointments.AppointmentDateSlotId);
                keyValuePairs.Add("@PatientEmail", patientAppointments.PatientEmail);
                keyValuePairs.Add("@PatientName", patientAppointments.PatientName);
                keyValuePairs.Add("@PatientPhoneNo", patientAppointments.PatientPhoneNo);
                keyValuePairs.Add("@Status", patientAppointments.Status);
                keyValuePairs.Add("@Comment", patientAppointments.Comment ?? string.Empty);
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

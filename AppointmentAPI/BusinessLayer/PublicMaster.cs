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
    public class PublicMaster
    {
        PublicDBAccess publicDBAccess;
        public PublicMaster()
        {
            publicDBAccess = new PublicDBAccess();
        }

        public List<User> GetDoctorsList()
        {
            List<User> users = new List<User>();
            try
            {
                DataTable dtusers = publicDBAccess.GetDoctorList();
                users = (from DataRow dr in dtusers.Rows
                         select new User()
                         {
                             Id = Convert.ToInt32(dr["Id"]),
                             Email = Convert.ToString(dr["Email"]),
                             Name = Convert.ToString(dr["Name"]),
                             PhoneNo = Convert.ToString(dr["PhoneNo"]),
                             CreatedOn= Convert.ToDateTime(dr["CreatedOn"])
                         }).ToList();
            }
            catch
            {
                throw;
            }
            return users;
        }

        public List<User> GetDoctorsAppointmetByDate(ReqDateAppointment reqDateAppointment)
        {
            List<User> users = new List<User>();
            try
            {
                //DoctorMaster doctorMaster = new DoctorMaster()
                //DataTable dtusers = publicDBAccess.GetDoctorList();
                //users = (from DataRow dr in dtusers.Rows
                //         select new User()
                //         {
                //             Id = Convert.ToInt32(dr["Id"]),
                //             Email = Convert.ToString(dr["Email"]),
                //             Name = Convert.ToString(dr["Name"]),
                //             PhoneNo = Convert.ToString(dr["PhoneNo"])
                //         }).ToList();
            }
            catch
            {
                throw;
            }
            return users;
        }

        public int BookAppointment(PatientAppointments patientAppointments)
        {
            int result = 0;
            try
            {
                result = publicDBAccess.BookAppointment(patientAppointments);
            }
            catch
            {
                throw;
            }
            return result;
        }

    }
}

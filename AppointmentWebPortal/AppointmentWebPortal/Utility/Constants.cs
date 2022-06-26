using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentWeb.Utility
{
    public static class Constants
    {
        public const string LogFileDirectory = "LogFileDirectory";
        public const string APIUrl = "APIUrl";
        public const string LogType = "LogType";
        public const string ConnectionString = "ConnectionString";
        public const string UserLoginDetails = "UserLoginDetails";
        public const string UserId = "UserId";
        public const string UserDetail = "UserDetail";
        public const string LoginResponse = "LoginResponse";
        public const string DateTimeFormateExport = "dd-MMM-yyyy";
        public const string Yes = "Yes";
        public const string No = "No";
        public const string Non = "Nil";


        public const string GetDoctorsList = "api/Public/GetDoctorsList";
        public const string GetAppointmentList = "api/Public/GetAppointmentList";
        public const string BookAppointment = "api/Public/BookAppointment";
        public const string RegisterUser = "api/account/Register";
        public const string ValidateUser = "api/account/ValidateUser";


        //doctor
        public const string DoctorAllSlots = "api/doctor/GetAllMySlots"; 
            public const string InsertDateSlots = "api/doctor/InsertDateSlots";
        public const string UpdateAppointmentStatus = "api/doctor/UpdateAppointmentStatus";

    }
}

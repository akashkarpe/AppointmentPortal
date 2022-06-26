using AppointmentAPI;
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
    public class AccountController : ApiController
    {
        AccountMaster accountMaster;
        public AccountController()
        {
            accountMaster = new AccountMaster();
        }
        [HttpPost]
        public Response Register([FromBody] User user)
        {
            Response res = new Response();
            try
            {
                LoginResponse loginResponse = new LoginResponse();
                if (accountMaster.RegisterUser(user)!= 0)
                {
                    loginResponse.Token = TokenManager.GenerateToken(user.Email);
                    loginResponse.DoctorId = accountMaster.GetDoctorIdFromEmail(user.Email);
                }
                res.Data = loginResponse;
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
        public Response ValidateUser([FromBody] Login login)
        {
            Response res = new Response();
            try
            {
                LoginResponse loginResponse = new LoginResponse();
                if (accountMaster.ValidateUser(login))
                {
                    loginResponse.Token = TokenManager.GenerateToken(login.Email);
                    loginResponse.DoctorId = accountMaster.GetDoctorIdFromEmail(login.Email);
                }
                res.Data = loginResponse;
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

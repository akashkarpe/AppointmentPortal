using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountMaster
    {
        AccountDBAccess accountDBAccess;
        public AccountMaster()
        {
            accountDBAccess = new AccountDBAccess();
        }
        public int GetDoctorIdFromEmail(string Email)
        {
            int result = 0;
            try
            {
                result = accountDBAccess.GetDoctorIdFromEmail(Email);
            }
            catch
            {
                throw;
            }
            return result;
        }
        public int RegisterUser(User user)
        {
            int result = 0;
            try
            {
                result = accountDBAccess.InsertUser(user);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public bool ValidateUser(Login login)
        {
            bool result = false;
            try
            {
                result = accountDBAccess.ValidateLogin(login);                
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}

using DataAccessLayer.DBHelper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDBAccess
    {
        private DataAccessLayer.DBHelper.DBHelper dbHelper;
        public AccountDBAccess()
        {
            dbHelper = new SQLHelper();
        }

        public int GetDoctorIdFromEmail(string Email)
        {
            int result = 0;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"select Id from Users where Email=@Email";
                keyValuePairs.Add("@Email", Email);
                result = Convert.ToInt32(dbHelper.GetScalarValue(keyValuePairs));
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int InsertUser(User user)
        {
            int result = 0;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"INSERT INTO Users(Email,Name,PhoneNo,UserType,CreatedOn)
                                values(@Email,@Name,@PhoneNo,@UserType,@CreatedOn);SELECT SCOPE_IDENTITY();";
                //keyValuePairs.Add("@Id", user.Id);
                keyValuePairs.Add("@Email", user.Email);
                keyValuePairs.Add("@Name", user.Name);
                keyValuePairs.Add("@PhoneNo", user.PhoneNo);
                keyValuePairs.Add("@UserType", user.UserType);
                keyValuePairs.Add("@CreatedOn", DateTime.Now);
                result = Convert.ToInt32(dbHelper.GetScalarValue(keyValuePairs));
                dbHelper.Query = @"INSERT INTO Credentials(Password,UserId)
                                values(@Password,@UserId);SELECT SCOPE_IDENTITY();";
                keyValuePairs.Add("@Password", user.Password);
                keyValuePairs.Add("@UserId", result);
                result = dbHelper.ExecuteNonQuery(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public bool ValidateLogin(Login login)
        {
            bool result = false;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"select count(u.Id) from Users u inner join Credentials c on u.Id=c.UserId
                    where u.Email=@Email and c.Password=@Password";
                keyValuePairs.Add("@Email", login.Email);
                keyValuePairs.Add("@Password", login.Password);
                if (Convert.ToInt32(dbHelper.GetScalarValue(keyValuePairs)) == 1)
                {
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}

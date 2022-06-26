using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBHelper
{
    public class SQLHelper: DBHelper
    {
        private string _connstr;

        public SQLHelper()
        {
            _connstr = Convert.ToString(ConfigurationManager.ConnectionStrings["AppointmentAPI"]);
        }

        public override DataTable GetDataSet(Dictionary<string, object> paramsList)
        {
            var dataTable = new DataTable();
            try
            {
                using (var connection = new SqlConnection(_connstr))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(Query, connection))
                    {
                        foreach (var paramd in paramsList)
                        {
                            cmd.Parameters.AddWithValue(paramd.Key, paramd.Value);
                        }
                        var reader = cmd.ExecuteReader();
                        dataTable.Load(reader);
                    }
                }
            }
            catch
            {
                throw;
            }
            return dataTable;

        }

        public override int ExecuteNonQuery(Dictionary<string, object> paramsList)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(_connstr))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(Query, connection))
                    {
                        foreach (var paramd in paramsList)
                        {
                            cmd.Parameters.AddWithValue(paramd.Key, paramd.Value);
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public override object GetScalarValue(Dictionary<string, object> paramsList)
        {
            object result = 0;
            try
            {
                using (var connection = new SqlConnection(_connstr))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(Query, connection))
                    {
                        foreach (var paramd in paramsList)
                        {
                            cmd.Parameters.AddWithValue(paramd.Key, paramd.Value);
                        }
                        result = cmd.ExecuteScalar();
                    }
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

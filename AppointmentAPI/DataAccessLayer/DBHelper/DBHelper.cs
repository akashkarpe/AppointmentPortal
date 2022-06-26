using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBHelper
{
    public abstract class DBHelper
    {
        public string Query;
        public abstract object GetScalarValue(Dictionary<string, object> paramsList);
        public abstract DataTable GetDataSet(Dictionary<string, object> paramsList);
        public abstract int ExecuteNonQuery(Dictionary<string, object> paramsList);
    }
}

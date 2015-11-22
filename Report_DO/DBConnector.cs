using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_DO
{
   public class DBConnector
    {
        private string connectionString = null;
        private SqlConnection sqlConn = null;
        private SqlCommand cmd = null;

        public DBConnector()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PMSReports"].ToString();
        }

        public SqlCommand GetCommand()
        {
            cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            return cmd;
        }

        public SqlConnection GetConn()
        {
            sqlConn = new SqlConnection(connectionString);
            return sqlConn;
        }
    }
}

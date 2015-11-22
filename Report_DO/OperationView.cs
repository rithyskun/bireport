using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_DO
{
    public class OperationView
    {
        public void GetOperationReport(System.Nullable<DateTime> StartDate, System.Nullable<DateTime> EndDate)
        {
            
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PMSReports"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SPOperation",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);                
                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

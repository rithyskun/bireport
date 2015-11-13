using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Report_DO
{
    public class OperateDO : DbConnectivity
    {
        private SqlDataAdapter _adapter;
        private SqlConnection _cn;
        private SqlCommand _selectCommand;
        public DataTable GetOperationReport(DateTime StartDate, DateTime EndDate)
        {
            var resultDt = new DataTable();
            _selectCommand = new SqlCommand();
            _adapter = new SqlDataAdapter();
            const string procname = "SPOperation";
            try
            {
                _cn = Connection;
                _selectCommand.Connection = _cn;
                _selectCommand.CommandText = procname;
                _selectCommand.CommandType = CommandType.StoredProcedure;
                _selectCommand.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                _selectCommand.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                _adapter.SelectCommand = _selectCommand;
                _adapter.Fill(resultDt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cn.Close();
                _selectCommand.Dispose();
            }

            return resultDt;
        }
        
    
    }
}

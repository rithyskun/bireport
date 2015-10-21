using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Report_DO;
namespace Report_DO
{
    public class OperateDO: DbConnectivity
    {
        public IEnumerable<OperationReport> OperateRP(DateTime stDate, DateTime endDate)
        {
            
            var dataList = new List<OperationReport>();
            var command = new SqlCommand();
            try
            {
                var cn = Connection;
                command.Connection = cn;
                command.CommandText = "SPOperation";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BeginDate", SqlDbType.DateTime).Value = stDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataList.Add(Helper.GetAs<OperationReport>(reader));
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataList;
        }
    }
    }


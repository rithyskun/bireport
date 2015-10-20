using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Report_DO;
using Report_UI.DataContexts;
using System.Data.SqlClient;

namespace Report_UI.Controllers
{
        public class OperationReportController : DbConnectivity
    {

        private ReportIdentity db = new ReportIdentity();

        // GET: /OperationReport/
        public ActionResult Index()
        {

            
        }
        
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

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        db.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}
}


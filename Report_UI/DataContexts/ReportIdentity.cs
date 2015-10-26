using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Report_DO;
using System.Diagnostics;

namespace Report_UI.DataContexts
{
    public class ReportIdentity: DbContext
    {
        //Default "DefaultConnection"
        public ReportIdentity()
            : base("PMSReports")
        {
            //Database.SetInitializer<ReportIdentity>(null);
            //Database.Log = sql => Debug.Write(sql);
        }
        
        public DbSet<MasterReport> TBMasterReportList { get; set; }
        public DbSet<KPICal> TBKPICalculation { get; set; }
        public DbSet<ParamConfig> TBParameters { get; set; }
        public DbSet<TBReportGroup> TBReportGroup { get; set; }
        public DbSet<TrafficInOutBound> tbTrafficInOutbound_BSC_Detail { get; set; }

        public DbSet<OperationReport> OperationReports { get; set; }

        public DbSet<ReportSchemaMapping> TBReportSchemaMapping { get; set; }

        public DbSet<SubReport> TBSubReport { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                          
        }
        
    }
}
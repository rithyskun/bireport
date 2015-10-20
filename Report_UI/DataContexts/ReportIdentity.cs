﻿using System;
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
            Database.SetInitializer<ReportIdentity>(null);
            Database.Log = sql => Debug.Write(sql);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public DbSet<MasterReport> TBMasterReportList { get; set; }
        public DbSet<KPICal> TBKPICalculation { get; set; }
        public DbSet<ParamConfig> TBParameters { get; set; }
        public DbSet<TBReportGroup> TBReportGroup { get; set; }
        public DbSet<TrafficInOutBound> tbTrafficInOutbound_BSC_Detail { get; set; }

        public System.Data.Entity.DbSet<Report_DO.OperationReport> OperationReports { get; set; }

        
        
        
    }
}
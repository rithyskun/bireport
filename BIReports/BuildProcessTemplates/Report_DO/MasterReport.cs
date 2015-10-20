using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList.Mvc;
using PagedList;


namespace Report_DO
{
    [Table("TBMasterReportList")]
    public class MasterReport
    {
        [Key]
        [Display(Name = "Report ID")]
        public int MasterReportListID { get; set; }
        [Display(Name = "Report Name")]
        public string MasterReportListName { get; set; }
       
        
    }

    [Table("TBKPICalculation")]
    public class KPICal
    {
        [Key]        
        public int KPICalculationId { get; set; }          
        public int ReportGroupID { get; set; }
        public string KPIName { get; set; }
        public string KPINameDesc { get; set; }
        public string KPIType { get; set; }      
        public string KPIFormula { get; set; }

       
        
    }

    [Table("TBParameters")]
    public class ParamConfig
    {
        [Key]
        public int PId { get; set; }
        public int MasterReportId { get; set; }
        public string PKeyName { get; set; }
        public string PkeyValue { get; set; }

    }

    public class TBReportGroup
    {
        [Key]
        public int ReportGroupID { get; set; }
        public string ReportGroup { get; set; }       
        public int MasterReportListID { get; set; }
       
    }
    
    [Table("tbTrafficInOutBound_BSC_Detail")]
    public class TrafficInOutBound
    {
        
        public string ResultTime { get; set; }
        public string HourOfDay { get; set; }
        public string GranularityPeriod { get; set; }
        public string NEName { get; set; }       
        public string BSCName { get; set; }
        [Key]
        public string OfficeDir { get; set; }
        public decimal Answer_Traffic_Incoming { get; set; }
        public decimal Answer_Traffic_Outgoing { get; set; }
        public decimal Total_Traffic_BSC { get; set; }
       
    }
    public class ReportIndexData
    {
        public IEnumerable<MasterReport> MasterReports {get;set;}
        public IEnumerable<TrafficInOutBound> TrafficInOutbounds { get; set; }
        public IEnumerable<KPICal> KPICals { get; set; }
    }
   
}

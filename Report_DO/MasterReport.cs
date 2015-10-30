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
        public virtual ICollection<SubReport> SubReports { get; set; }
         
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
        [Display(Name = "Master Report ID")]
        public int MasterReportId { get; set; }
        [Display(Name = "Key Name")]
        public string PKeyName { get; set; }
        [Display(Name = "Key Value")]
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
    [Table("TBReportSchemaMapping")]
    public class ReportSchemaMapping
    {  
      [Key]  
      public int ReportSchemaMappingID { get; set; }
      public int ReportGroupID { get; set; }
      public string SPName { get; set; }
      public string FileIdentifier { get; set; }
      public string RawTableName { get; set; }
      public string FieldDelimiter { get; set; }
      public string RowDelimiter { get; set; }
      public string RawFilelocation { get; set; }
      public string FTPSiteAddress { get; set; }
      public string FTPSiteUsername { get; set; }
      public string FTPSitePassword { get; set; }
      public string FTPSiteDirectory { get; set; }
      public string WorkDirectory { get; set; }
      public string FTPSPName { get; set; }

    }
   
   [Table("TBBoardClass")]
   public class BoradClass
   {
       [Key]
       public int BoardClassId { get; set; }
       public string BoardClass { get; set; }
   }

    [Table("TBBoardType")]
    public class BoardType
    {
        [Key]
        public int BoardTypeId { get; set; }
        [Display(Name = "BSC Name ID")]
        public int BSCNameID { get; set; }
        [Display(Name = "Sub Rack No")]
        public string SubRackNo { get; set; }
        [Display(Name = "Slot No")]
        public string SlotNo { get; set; }
        [Display(Name = "Board Type")]
        public string Boardtype { get; set; }
        [Display(Name = "Logical Function Type")]
        public string LogicalFunctionType { get; set; }
    }

    [Table("TBBSCName")]
    public class BSCNames
    {
        [Key]
        public int BSCNameID { get; set; }
        public string BSCName { get; set; }
    }

    [Table("TBGCellList")]
    public class GCellList
    {
        [Key]
        public int GCellID { get; set; }
        [Display(Name = "BSC ID")]
        public int BSCNameID { get; set; }
        [Display(Name = "GCell Name")]
        public string GCellName { get; set; }
        [Display(Name = "GCell Value")]
        public string GCellValue { get; set; }        
        public string Province { get; set; }
    }

    [Table("tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission")]
    public class DataComGBLinkCap
    {
        [Key]
        public int Id { get; set; }
        public string BSCName { get; set; }
        public decimal GBLinkCapacity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.Nullable<DateTime> BeginDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]    
        public System.Nullable<DateTime> EndDate { get; set; }
    }

    [Table("TBTRC_GBInterface_GBValue")]
    public class GBInterface
    {
        [Key]
        public string BSCName { get; set; }
        public decimal GBValue { get; set; }
    }

    [Table("TBTXNFMENgineerList")]
    public class FMEngineers
    {
        [Key]
        public int FMEngineerListID { get; set; }
        public string SiteName { get; set; }
        public string FMEngineer { get; set; }
    }

    [Table("tbTXNRSLSiteList")]
    public class SiteList
    {
        [Key]
        public int SiteID { get; set; }
        public string SiteName { get; set; }
    }

    [Table("TBTXNLinkBudget")]
    public class TXNLinkBudget
    {
        [Key]
        public int LinkBudgetID { get; set; }
        public string Hop { get; set; }        
        public string Config { get; set; }
        public string RSLValue { get; set; }
    }
    [Table("TBTXNLinkBudgetSD")]
    public class TXNLinkBudgetSD
    {
        [Key]
        public int LinkBudgetID { get; set; }
        public string Hop { get; set; }
        public string LinkName { get; set; }
        public string Config { get; set; }
        public string RSLValue { get; set; }
    }

    [Table("tbMasterReportDate")]
    public class MasterReportDate
    {
        [Key]
        public int MasterReportListID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.Nullable<DateTime> ReportDate { get; set; }
        //public DateTime ReportDate { get; set; }
        public string RunStatus { get; set; }
    }
}

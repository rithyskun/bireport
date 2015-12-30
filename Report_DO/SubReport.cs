using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_DO
{
    [Table("TBSubReport")]
    public class SubReport
    {
        [Key]
        public int MasterReportID { get; set; }
        public string SubReportName { get; set; }
        public virtual MasterReport MasterReports { get; set; }
    }
}

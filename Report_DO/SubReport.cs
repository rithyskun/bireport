using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_DO
{
    [Table("TBSubReport")]
    public class SubReport
    {
        [Key]
        public int MasterReportID { get; set; }
        public string SubReportName { get; set; }       
        
    }
}

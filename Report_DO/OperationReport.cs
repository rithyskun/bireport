using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_DO
{
    public class OperationReport
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
           "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
           "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public string ResultTime { get; set; }
        public string CSSR { get; set; }
        public string TCHCongestion { get; set; }
        public string SDCCHCongestion { get; set; }
        public string SDCDR { get; set; }
        public string HOSR { get; set; }
        public string CDR { get; set; }
        public string Traffic_24H { get; set; }
        public string Traffic_BH { get; set; }
        public string TotalGPRS_EDGE_Traffic { get; set; }
        public string NSSVoice_Traffic_24H { get; set; }
        public string NSSVoice_Traffic_BH { get; set; }
        public string PagingSuccess_Rate { get; set; }
        public string AssignmentSuccess_Rate { get; set; }
        public string SMS_MOSuccess_Rate { get; set; }
        public string SMS_MTSuccess_Rate { get; set; }
        public string BHCA_Utilization { get; set; }
        public string CSR { get; set; }
        public string VLRSub { get; set; }
        public string HLRSub { get; set; }
        public string VLRInt_RoamingSub { get; set; }
        public string Total_Traffic_GGSN { get; set; }

        public string MWLinkRSL { get; set; }
        public string MWLinkRSL_Low { get; set; }
        public string MWLinkES { get; set; }
        public string MWLinkSES { get; set; }
        public string MWLinkUAS { get; set; }

        public IEnumerable<OperationReport> OperateRP { get; set; }
    }
}

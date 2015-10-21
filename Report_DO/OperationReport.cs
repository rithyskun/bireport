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
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
           "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }        

        public IEnumerable<dataList> datalist { get; set; }
    }
}

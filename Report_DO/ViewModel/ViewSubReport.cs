using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Report_DO.ViewModel
{
    public class ViewSubReport
    {
        public IEnumerable<SubReport> SubReports { get; set; }
        public IEnumerable<MasterReport> MasterReports { get; set; }
    }
}

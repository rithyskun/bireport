using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Report_DO;
using Report_UI.DataContexts;
using PagedList;

namespace Report_UI.Controllers
{
    [Authorize]
    public class TrafficInOutController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /TrafficInOut/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "ResultTime" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var TRAFFIC = from tra in db.tbTrafficInOutbound_BSC_Detail select tra;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                TRAFFIC = TRAFFIC.Where(tra => tra.ResultTime.ToUpper().Contains(Search_Data.ToUpper())
                    || tra.BSCName.ToUpper().Contains(Search_Data.ToUpper()));               
            }

            switch (Sorting_Order)
            {
                case "ResultTime":
                    TRAFFIC = TRAFFIC.OrderByDescending(tra => tra.ResultTime);
                    break;
                default:
                    TRAFFIC = TRAFFIC.OrderByDescending(tra => tra.ResultTime);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(TRAFFIC.ToPagedList(No_Of_Page, Size_Of_Page));

            //return View(db.tbTrafficInOutbound_BSC_Detail.ToList());
        }
            
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

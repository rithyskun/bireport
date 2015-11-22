using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Report_DO;
using Report_UI.DataContexts;
using PagedList;

namespace Report_UI.Controllers
{
    public class MasterReportDateController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /MasterReportDate/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "ReportID" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "RunStatus" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var reportdate = from rdate in db.tbMasterReportDate select rdate;
            if (!String.IsNullOrEmpty(Search_Data))
            {

                reportdate = reportdate.Where(rdate => rdate.RunStatus.ToUpper().Contains(Search_Data.ToUpper()));
                //|| rdate.RunStatus.ToUpper().Contains(Search_Data.ToUpper()));

            }

            switch (Sorting_Order)
            {
                case "ReportID":
                    reportdate = reportdate.OrderByDescending(rdate => rdate.ReportDate);
                    break;
                case "RunStatus":
                    reportdate = reportdate.OrderByDescending(rdate => rdate.RunStatus);
                    break;
                default:
                    reportdate = reportdate.OrderBy(rdate => rdate.ReportDate);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(reportdate.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: /MasterReportDate/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterReportDate masterreportdate = db.tbMasterReportDate.Find(id);
            if (masterreportdate == null)
            {
                return HttpNotFound();
            }
            return View(masterreportdate);
        }

        // GET: /MasterReportDate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MasterReportDate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReportDate,MasterReportListID,RunStatus")] MasterReportDate masterreportdate)
        {
            if (ModelState.IsValid)
            {
                db.tbMasterReportDate.Add(masterreportdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterreportdate);
        }

        // GET: /MasterReportDate/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MasterReportDate masterreportdate = db.tbMasterReportDate.Find(id);

            MasterReportDate masterreportdate = db.tbMasterReportDate.Find(id);
            if (masterreportdate == null)
            {
                return HttpNotFound();
            }
            return View(masterreportdate);
        }

        // POST: /MasterReportDate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReportDate,MasterReportListID,RunStatus")] MasterReportDate masterreportdate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterreportdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterreportdate);
        }

        // GET: /MasterReportDate/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterReportDate masterreportdate = db.tbMasterReportDate.Find(id);
            if (masterreportdate == null)
            {
                return HttpNotFound();
            }
            return View(masterreportdate);
        }

        // POST: /MasterReportDate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MasterReportDate masterreportdate = db.tbMasterReportDate.Find(id);
            db.tbMasterReportDate.Remove(masterreportdate);
            db.SaveChanges();
            return RedirectToAction("Index");
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

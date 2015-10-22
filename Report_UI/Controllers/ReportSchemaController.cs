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
    public class ReportSchemaController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /ReportSchema/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "SPName" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "RawTableName" : "";
            
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var schema = from scm in db.TBReportSchemaMapping select scm;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                schema = schema.Where(scm => scm.RowDelimiter.ToUpper().Contains(Search_Data.ToUpper())                    
                    || scm.RawTableName.ToUpper().Contains(Search_Data.ToUpper())
                    || scm.RawFilelocation.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "SPName":
                    schema = schema.OrderByDescending(scm=>scm.SPName);
                    break;
                case "RawTableName":
                    schema = schema.OrderBy(scm => scm.RawTableName);
                    break;
                
                default:
                    schema = schema.OrderBy(scm => scm.ReportGroupID);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(schema.ToPagedList(No_Of_Page, Size_Of_Page));     
        }

        // GET: /ReportSchema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportSchemaMapping reportschemamapping = db.TBReportSchemaMapping.Find(id);
            if (reportschemamapping == null)
            {
                return HttpNotFound();
            }
            return View(reportschemamapping);
        }

        // GET: /ReportSchema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ReportSchema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReportSchemaMappingID,ReportGroupID,SPName,FileIdentifier,RawTableName,FieldDelimiter,RowDelimiter,RawFilelocation,FTPSiteAddress,FTPSiteUsername,FTPSitePassword,FTPSiteDirectory,WorkDirectory,FTPSPName")] ReportSchemaMapping reportschemamapping)
        {
            if (ModelState.IsValid)
            {
                db.TBReportSchemaMapping.Add(reportschemamapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportschemamapping);
        }

        // GET: /ReportSchema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportSchemaMapping reportschemamapping = db.TBReportSchemaMapping.Find(id);
            if (reportschemamapping == null)
            {
                return HttpNotFound();
            }
            return View(reportschemamapping);
        }

        // POST: /ReportSchema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReportSchemaMappingID,ReportGroupID,SPName,FileIdentifier,RawTableName,FieldDelimiter,RowDelimiter,RawFilelocation,FTPSiteAddress,FTPSiteUsername,FTPSitePassword,FTPSiteDirectory,WorkDirectory,FTPSPName")] ReportSchemaMapping reportschemamapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportschemamapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportschemamapping);
        }

        // GET: /ReportSchema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportSchemaMapping reportschemamapping = db.TBReportSchemaMapping.Find(id);
            if (reportschemamapping == null)
            {
                return HttpNotFound();
            }
            return View(reportschemamapping);
        }

        // POST: /ReportSchema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportSchemaMapping reportschemamapping = db.TBReportSchemaMapping.Find(id);
            db.TBReportSchemaMapping.Remove(reportschemamapping);
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

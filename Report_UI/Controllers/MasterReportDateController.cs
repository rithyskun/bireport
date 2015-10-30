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

namespace Report_UI.Controllers
{
    public class MasterReportDateController : Controller
    {
        private ReportIdentity db = new ReportIdentity();
        
        // GET: /MasterReportDate/
        public ActionResult Index()
        {
            return View(db.tbMasterReportDate.ToList());
        }

        // GET: /MasterReportDate/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include="MasterReportListID,ReportDate,RunStatus")] MasterReportDate masterreportdate)
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
        public ActionResult Edit(int? id)
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

        // POST: /MasterReportDate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MasterReportListID,ReportDate,RunStatus")] MasterReportDate masterreportdate)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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

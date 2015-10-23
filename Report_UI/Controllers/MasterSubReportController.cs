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
    public class MasterSubReportController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /MasterSubReport/
        public ActionResult Index()
        {
            return View(db.TBSubReport.ToList());
        }

        // GET: /MasterSubReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubReport subreport = db.TBSubReport.Find(id);
            if (subreport == null)
            {
                return HttpNotFound();
            }
            return View(subreport);
        }

        // GET: /MasterSubReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MasterSubReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MasterReportID,SubReportName")] SubReport subreport)
        {
            if (ModelState.IsValid)
            {
                db.TBSubReport.Add(subreport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subreport);
        }

        // GET: /MasterSubReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubReport subreport = db.TBSubReport.Find(id);
            if (subreport == null)
            {
                return HttpNotFound();
            }
            return View(subreport);
        }

        // POST: /MasterSubReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MasterReportID,SubReportName")] SubReport subreport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subreport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subreport);
        }

        // GET: /MasterSubReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubReport subreport = db.TBSubReport.Find(id);
            if (subreport == null)
            {
                return HttpNotFound();
            }
            return View(subreport);
        }

        // POST: /MasterSubReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubReport subreport = db.TBSubReport.Find(id);
            db.TBSubReport.Remove(subreport);
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

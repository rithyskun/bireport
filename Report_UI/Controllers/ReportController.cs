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
using Report_DO.ViewModel;

namespace Report_UI.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /Report/
        public ActionResult Index (int? id)
        {
            //var ViewSub = new ViewSubReport();
            //ViewSub.MasterReports = db.TBMasterReportList                
            //    .Include(i => i.SubReports.Select(c => c.SubReportName))
            //    .Include(i=>i.SubReports.Select(c=>c.MasterReportID));                

            if (id != null)
            {
                ViewBag.MasterReportListID = id.Value;
                //ViewSub.SubReports = ViewSub.MasterReports.Where(c => c.MasterReportListID == id.Value).Single().SubReports;

            }

           //return View(ViewSub);          
            return View(db.TBMasterReportList.ToList());
        }

        // GET: /Report/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterReport masterreport = db.TBMasterReportList.Find(id);
            if (masterreport == null)
            {
                return HttpNotFound();
            }
            return View(masterreport);
        }

        // GET: /Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MasterReportListID,MasterReportListName")] MasterReport masterreport)
        {
            if (ModelState.IsValid)
            {
                db.TBMasterReportList.Add(masterreport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterreport);
        }

        // GET: /Report/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterReport masterreport = db.TBMasterReportList.Find(id);
            if (masterreport == null)
            {
                return HttpNotFound();
            }
            return View(masterreport);
        }

        // POST: /Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MasterReportListID,MasterReportListName")] MasterReport masterreport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterreport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterreport);
        }

        // GET: /Report/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterReport masterreport = db.TBMasterReportList.Find(id);
            if (masterreport == null)
            {
                return HttpNotFound();
            }
            return View(masterreport);
        }

        // POST: /Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterReport masterreport = db.TBMasterReportList.Find(id);
            db.TBMasterReportList.Remove(masterreport);
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

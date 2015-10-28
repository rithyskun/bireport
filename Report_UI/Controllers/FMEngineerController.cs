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
    public class FMEngineerController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /FMEngineer/
        public ActionResult Index()
        {
            return View(db.TBTXNFMENgineerList.ToList());
        }

        // GET: /FMEngineer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            if (fmengineers == null)
            {
                return HttpNotFound();
            }
            return View(fmengineers);
        }

        // GET: /FMEngineer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FMEngineer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FMEngineerListID,SiteName,FMEngineer")] FMEngineers fmengineers)
        {
            if (ModelState.IsValid)
            {
                db.TBTXNFMENgineerList.Add(fmengineers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fmengineers);
        }

        // GET: /FMEngineer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            if (fmengineers == null)
            {
                return HttpNotFound();
            }
            return View(fmengineers);
        }

        // POST: /FMEngineer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FMEngineerListID,SiteName,FMEngineer")] FMEngineers fmengineers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fmengineers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fmengineers);
        }

        // GET: /FMEngineer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            if (fmengineers == null)
            {
                return HttpNotFound();
            }
            return View(fmengineers);
        }

        // POST: /FMEngineer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            db.TBTXNFMENgineerList.Remove(fmengineers);
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

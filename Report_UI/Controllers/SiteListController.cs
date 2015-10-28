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
    public class SiteListController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /SiteList/
        public ActionResult Index()
        {
            return View(db.tbTXNRSLSiteList.ToList());
        }

        // GET: /SiteList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            if (sitelist == null)
            {
                return HttpNotFound();
            }
            return View(sitelist);
        }

        // GET: /SiteList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SiteList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SiteID,SiteName")] SiteList sitelist)
        {
            if (ModelState.IsValid)
            {
                db.tbTXNRSLSiteList.Add(sitelist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitelist);
        }

        // GET: /SiteList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            if (sitelist == null)
            {
                return HttpNotFound();
            }
            return View(sitelist);
        }

        // POST: /SiteList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SiteID,SiteName")] SiteList sitelist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitelist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitelist);
        }

        // GET: /SiteList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            if (sitelist == null)
            {
                return HttpNotFound();
            }
            return View(sitelist);
        }

        // POST: /SiteList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            db.tbTXNRSLSiteList.Remove(sitelist);
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

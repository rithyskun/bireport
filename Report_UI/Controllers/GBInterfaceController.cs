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
    public class GBInterfaceController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /GBInterface/
        public ActionResult Index()
        {
            return View(db.TBTRC_GBInterface_GBValue.ToList());
        }

        // GET: /GBInterface/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GBInterface gbinterface = db.TBTRC_GBInterface_GBValue.Find(id);
            if (gbinterface == null)
            {
                return HttpNotFound();
            }
            return View(gbinterface);
        }

        // GET: /GBInterface/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GBInterface/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BSCName,GBValue")] GBInterface gbinterface)
        {
            if (ModelState.IsValid)
            {
                db.TBTRC_GBInterface_GBValue.Add(gbinterface);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gbinterface);
        }

        // GET: /GBInterface/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GBInterface gbinterface = db.TBTRC_GBInterface_GBValue.Find(id);
            if (gbinterface == null)
            {
                return HttpNotFound();
            }
            return View(gbinterface);
        }

        // POST: /GBInterface/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BSCName,GBValue")] GBInterface gbinterface)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gbinterface).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gbinterface);
        }

        // GET: /GBInterface/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GBInterface gbinterface = db.TBTRC_GBInterface_GBValue.Find(id);
            if (gbinterface == null)
            {
                return HttpNotFound();
            }
            return View(gbinterface);
        }

        // POST: /GBInterface/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GBInterface gbinterface = db.TBTRC_GBInterface_GBValue.Find(id);
            db.TBTRC_GBInterface_GBValue.Remove(gbinterface);
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

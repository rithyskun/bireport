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
    public class BSCNameController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /BSCName/
        public ActionResult Index()
        {
            return View(db.TBBSCName.ToList());
        }

        // GET: /BSCName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCNames bscnames = db.TBBSCName.Find(id);
            if (bscnames == null)
            {
                return HttpNotFound();
            }
            return View(bscnames);
        }

        // GET: /BSCName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BSCName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BSCNameID,BSCName")] BSCNames bscnames)
        {
            if (ModelState.IsValid)
            {
                db.TBBSCName.Add(bscnames);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bscnames);
        }

        // GET: /BSCName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCNames bscnames = db.TBBSCName.Find(id);
            if (bscnames == null)
            {
                return HttpNotFound();
            }
            return View(bscnames);
        }

        // POST: /BSCName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BSCNameID,BSCName")] BSCNames bscnames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bscnames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bscnames);
        }

        // GET: /BSCName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCNames bscnames = db.TBBSCName.Find(id);
            if (bscnames == null)
            {
                return HttpNotFound();
            }
            return View(bscnames);
        }

        // POST: /BSCName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSCNames bscnames = db.TBBSCName.Find(id);
            db.TBBSCName.Remove(bscnames);
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

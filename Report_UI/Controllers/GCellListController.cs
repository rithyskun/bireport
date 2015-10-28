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
    public class GCellListController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /GCellList/
        public ActionResult Index()
        {
            return View(db.TBGCellList.ToList());
        }

        // GET: /GCellList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCellList gcelllist = db.TBGCellList.Find(id);
            if (gcelllist == null)
            {
                return HttpNotFound();
            }
            return View(gcelllist);
        }

        // GET: /GCellList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GCellList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GCellID,BSCNameID,GCellName,GCellValue,Province")] GCellList gcelllist)
        {
            if (ModelState.IsValid)
            {
                db.TBGCellList.Add(gcelllist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gcelllist);
        }

        // GET: /GCellList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCellList gcelllist = db.TBGCellList.Find(id);
            if (gcelllist == null)
            {
                return HttpNotFound();
            }
            return View(gcelllist);
        }

        // POST: /GCellList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GCellID,BSCNameID,GCellName,GCellValue,Province")] GCellList gcelllist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gcelllist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gcelllist);
        }

        // GET: /GCellList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCellList gcelllist = db.TBGCellList.Find(id);
            if (gcelllist == null)
            {
                return HttpNotFound();
            }
            return View(gcelllist);
        }

        // POST: /GCellList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GCellList gcelllist = db.TBGCellList.Find(id);
            db.TBGCellList.Remove(gcelllist);
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

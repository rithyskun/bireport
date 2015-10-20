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
    [Authorize]
    public class ParametersController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /Parameters/
        public ActionResult Index()
        {
            return View(db.TBParameters.ToList());
        }

        // GET: /Parameters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamConfig paramconfig = db.TBParameters.Find(id);
            if (paramconfig == null)
            {
                return HttpNotFound();
            }
            return View(paramconfig);
        }

        // GET: /Parameters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Parameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PId,MasterReportId,PKeyName,PkeyValue")] ParamConfig paramconfig)
        {
            if (ModelState.IsValid)
            {
                db.TBParameters.Add(paramconfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paramconfig);
        }

        // GET: /Parameters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamConfig paramconfig = db.TBParameters.Find(id);
            if (paramconfig == null)
            {
                return HttpNotFound();
            }
            return View(paramconfig);
        }

        // POST: /Parameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PId,MasterReportId,PKeyName,PkeyValue")] ParamConfig paramconfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paramconfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paramconfig);
        }

        // GET: /Parameters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamConfig paramconfig = db.TBParameters.Find(id);
            if (paramconfig == null)
            {
                return HttpNotFound();
            }
            return View(paramconfig);
        }

        // POST: /Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParamConfig paramconfig = db.TBParameters.Find(id);
            db.TBParameters.Remove(paramconfig);
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

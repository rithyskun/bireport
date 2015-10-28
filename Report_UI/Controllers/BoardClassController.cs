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
    public class BoardClassController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /BoardClass/
        public ActionResult Index()
        {
            return View(db.TBBoardClass.ToList());
        }

        // GET: /BoardClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoradClass boradclass = db.TBBoardClass.Find(id);
            if (boradclass == null)
            {
                return HttpNotFound();
            }
            return View(boradclass);
        }

        // GET: /BoardClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BoardClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BoardClassId,BoardClass")] BoradClass boradclass)
        {
            if (ModelState.IsValid)
            {
                db.TBBoardClass.Add(boradclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boradclass);
        }

        // GET: /BoardClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoradClass boradclass = db.TBBoardClass.Find(id);
            if (boradclass == null)
            {
                return HttpNotFound();
            }
            return View(boradclass);
        }

        // POST: /BoardClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BoardClassId,BoardClass")] BoradClass boradclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boradclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boradclass);
        }

        // GET: /BoardClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoradClass boradclass = db.TBBoardClass.Find(id);
            if (boradclass == null)
            {
                return HttpNotFound();
            }
            return View(boradclass);
        }

        // POST: /BoardClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoradClass boradclass = db.TBBoardClass.Find(id);
            db.TBBoardClass.Remove(boradclass);
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

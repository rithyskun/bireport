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
    public class BoardTypeController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /BoardType/
        public ActionResult Index()
        {
            return View(db.TBBoardType.ToList());
        }

        // GET: /BoardType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardType boardtype = db.TBBoardType.Find(id);
            if (boardtype == null)
            {
                return HttpNotFound();
            }
            return View(boardtype);
        }

        // GET: /BoardType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BoardType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BoardTypeId,BSCNameID,SubRackNo,SlotNo,Boardtype,LogicalFunctionType")] BoardType boardtype)
        {
            if (ModelState.IsValid)
            {
                db.TBBoardType.Add(boardtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boardtype);
        }

        // GET: /BoardType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardType boardtype = db.TBBoardType.Find(id);
            if (boardtype == null)
            {
                return HttpNotFound();
            }
            return View(boardtype);
        }

        // POST: /BoardType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BoardTypeId,BSCNameID,SubRackNo,SlotNo,Boardtype,LogicalFunctionType")] BoardType boardtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardtype);
        }

        // GET: /BoardType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardType boardtype = db.TBBoardType.Find(id);
            if (boardtype == null)
            {
                return HttpNotFound();
            }
            return View(boardtype);
        }

        // POST: /BoardType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardType boardtype = db.TBBoardType.Find(id);
            db.TBBoardType.Remove(boardtype);
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

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
    public class LinkBudgetSDController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /LinkBudgetSD/
        public ActionResult Index()
        {
            return View(db.TBTXNLinkBudgetSD.ToList());
        }

        // GET: /LinkBudgetSD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXNLinkBudgetSD txnlinkbudgetsd = db.TBTXNLinkBudgetSD.Find(id);
            if (txnlinkbudgetsd == null)
            {
                return HttpNotFound();
            }
            return View(txnlinkbudgetsd);
        }

        // GET: /LinkBudgetSD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LinkBudgetSD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LinkBudgetID,Hop,LinkName,Config,RSLValue")] TXNLinkBudgetSD txnlinkbudgetsd)
        {
            if (ModelState.IsValid)
            {
                db.TBTXNLinkBudgetSD.Add(txnlinkbudgetsd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(txnlinkbudgetsd);
        }

        // GET: /LinkBudgetSD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXNLinkBudgetSD txnlinkbudgetsd = db.TBTXNLinkBudgetSD.Find(id);
            if (txnlinkbudgetsd == null)
            {
                return HttpNotFound();
            }
            return View(txnlinkbudgetsd);
        }

        // POST: /LinkBudgetSD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LinkBudgetID,Hop,LinkName,Config,RSLValue")] TXNLinkBudgetSD txnlinkbudgetsd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(txnlinkbudgetsd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(txnlinkbudgetsd);
        }

        // GET: /LinkBudgetSD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXNLinkBudgetSD txnlinkbudgetsd = db.TBTXNLinkBudgetSD.Find(id);
            if (txnlinkbudgetsd == null)
            {
                return HttpNotFound();
            }
            return View(txnlinkbudgetsd);
        }

        // POST: /LinkBudgetSD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TXNLinkBudgetSD txnlinkbudgetsd = db.TBTXNLinkBudgetSD.Find(id);
            db.TBTXNLinkBudgetSD.Remove(txnlinkbudgetsd);
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

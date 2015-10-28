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
    public class LinkBudgetController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /LinkBudget/
        public ActionResult Index()
        {
            return View(db.TBTXNLinkBudget.ToList());
        }

        // GET: /LinkBudget/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXNLinkBudget txnlinkbudget = db.TBTXNLinkBudget.Find(id);
            if (txnlinkbudget == null)
            {
                return HttpNotFound();
            }
            return View(txnlinkbudget);
        }

        // GET: /LinkBudget/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LinkBudget/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LinkBudgetID,Hop,Config,RSLValue")] TXNLinkBudget txnlinkbudget)
        {
            if (ModelState.IsValid)
            {
                db.TBTXNLinkBudget.Add(txnlinkbudget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(txnlinkbudget);
        }

        // GET: /LinkBudget/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXNLinkBudget txnlinkbudget = db.TBTXNLinkBudget.Find(id);
            if (txnlinkbudget == null)
            {
                return HttpNotFound();
            }
            return View(txnlinkbudget);
        }

        // POST: /LinkBudget/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LinkBudgetID,Hop,Config,RSLValue")] TXNLinkBudget txnlinkbudget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(txnlinkbudget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(txnlinkbudget);
        }

        // GET: /LinkBudget/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXNLinkBudget txnlinkbudget = db.TBTXNLinkBudget.Find(id);
            if (txnlinkbudget == null)
            {
                return HttpNotFound();
            }
            return View(txnlinkbudget);
        }

        // POST: /LinkBudget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TXNLinkBudget txnlinkbudget = db.TBTXNLinkBudget.Find(id);
            db.TBTXNLinkBudget.Remove(txnlinkbudget);
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

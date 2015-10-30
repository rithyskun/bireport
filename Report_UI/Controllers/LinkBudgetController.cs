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
using PagedList;

namespace Report_UI.Controllers
{
    public class LinkBudgetController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /LinkBudget/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Hop" : "";
            
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var linkbudget = from linkb in db.TBTXNLinkBudget select linkb;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                linkbudget = linkbudget.Where(linkb => linkb.Hop.ToUpper().Contains(Search_Data.ToUpper()));

            }

            switch (Sorting_Order)
            {
                case "Hop":
                    linkbudget = linkbudget.OrderByDescending(linkb => linkb.Hop);
                    break;
                default:
                    linkbudget = linkbudget.OrderBy(linkb => linkb.LinkBudgetID);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(linkbudget.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.TBTXNLinkBudget.ToList());
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

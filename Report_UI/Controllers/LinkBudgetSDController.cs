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
    public class LinkBudgetSDController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /LinkBudgetSD/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "HopName" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "LinkName" : "";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var linkbudgetsd = from linkb in db.TBTXNLinkBudgetSD select linkb;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                linkbudgetsd = linkbudgetsd.Where(linkb => linkb.Hop.ToUpper().Contains(Search_Data.ToUpper())
                    || linkb.LinkName.ToUpper().Contains(Search_Data.ToUpper()));

            }

            switch (Sorting_Order)
            {
                case "HopName":
                    linkbudgetsd = linkbudgetsd.OrderByDescending(linkb => linkb.Hop);
                    break;
                case "LinkName":
                    linkbudgetsd = linkbudgetsd.OrderByDescending(linkb => linkb.LinkName);
                    break;
                default:
                    linkbudgetsd = linkbudgetsd.OrderBy(linkb => linkb.LinkBudgetID);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(linkbudgetsd.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.TBTXNLinkBudgetSD.ToList());
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

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
    public class SiteListController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /SiteList/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "SiteID" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "SiteName" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var sitelist = from slist in db.tbTXNRSLSiteList select slist;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                sitelist = sitelist.Where(slist => slist.SiteName.ToUpper().Contains(Search_Data.ToUpper()));
                    
            }

            switch (Sorting_Order)
            {
                case "SiteName":
                    sitelist = sitelist.OrderByDescending(slist => slist.SiteName);
                    break;                
                default:
                    sitelist = sitelist.OrderBy(slist => slist.SiteID);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(sitelist.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.tbTXNRSLSiteList.ToList());
        }

        // GET: /SiteList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            if (sitelist == null)
            {
                return HttpNotFound();
            }
            return View(sitelist);
        }

        // GET: /SiteList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SiteList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SiteID,SiteName")] SiteList sitelist)
        {
            if (ModelState.IsValid)
            {
                db.tbTXNRSLSiteList.Add(sitelist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitelist);
        }

        // GET: /SiteList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            if (sitelist == null)
            {
                return HttpNotFound();
            }
            return View(sitelist);
        }

        // POST: /SiteList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SiteID,SiteName")] SiteList sitelist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitelist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitelist);
        }

        // GET: /SiteList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            if (sitelist == null)
            {
                return HttpNotFound();
            }
            return View(sitelist);
        }

        // POST: /SiteList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteList sitelist = db.tbTXNRSLSiteList.Find(id);
            db.tbTXNRSLSiteList.Remove(sitelist);
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

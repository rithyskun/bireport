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
    public class FMEngineerController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /FMEngineer/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "SaiteName" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "FMEngineer" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var fmengineer = from fm in db.TBTXNFMENgineerList select fm;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                fmengineer = fmengineer.Where(fm => fm.FMEngineer.ToUpper().Contains(Search_Data.ToUpper())
                    || fm.SiteName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "SiteName":
                    fmengineer = fmengineer.OrderByDescending(fm => fm.FMEngineer);
                    break;
                case "FMEngineer":
                    fmengineer = fmengineer.OrderByDescending(fm => fm.SiteName);
                    break;
                default:
                    fmengineer = fmengineer.OrderBy(fm => fm.FMEngineerListID);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(fmengineer.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.TBTXNFMENgineerList.ToList());
        }

        // GET: /FMEngineer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            if (fmengineers == null)
            {
                return HttpNotFound();
            }
            return View(fmengineers);
        }

        // GET: /FMEngineer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FMEngineer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FMEngineerListID,SiteName,FMEngineer")] FMEngineers fmengineers)
        {
            if (ModelState.IsValid)
            {
                db.TBTXNFMENgineerList.Add(fmengineers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fmengineers);
        }

        // GET: /FMEngineer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            if (fmengineers == null)
            {
                return HttpNotFound();
            }
            return View(fmengineers);
        }

        // POST: /FMEngineer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FMEngineerListID,SiteName,FMEngineer")] FMEngineers fmengineers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fmengineers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fmengineers);
        }

        // GET: /FMEngineer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            if (fmengineers == null)
            {
                return HttpNotFound();
            }
            return View(fmengineers);
        }

        // POST: /FMEngineer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FMEngineers fmengineers = db.TBTXNFMENgineerList.Find(id);
            db.TBTXNFMENgineerList.Remove(fmengineers);
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

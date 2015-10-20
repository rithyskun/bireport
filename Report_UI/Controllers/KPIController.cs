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
    [Authorize]
    public class KPIController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /KPI/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "KPIName" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "KPINameDesc" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "KPIType" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "KPIFormula" : "";

            if (Search_Data != null)
            {
                Page_No = 1;                
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var KPI = from kpi in db.TBKPICalculation select kpi;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                KPI = KPI.Where(kpi => kpi.KPIName.ToUpper().Contains(Search_Data.ToUpper()));
                    //|| kpi.KPINameDesc.ToUpper().Contains(Search_Data.ToUpper()));
                    //|| kpi.KPIType.ToUpper().Contains(Search_Data.ToUpper())
                    //|| kpi.KPIFormula.ToUpper().Contains(Search_Data.ToUpper()));
            }
            switch (Sorting_Order)
            {                
                case "KPIName":
                    KPI = KPI.OrderByDescending(kpi => kpi.KPIName);
                    break;
                case "KPINameDesc":
                    KPI = KPI.OrderByDescending(kpi => kpi.KPINameDesc);
                    break;
                case "KPIType":
                    KPI = KPI.OrderBy(kpi => kpi.KPIType);
                    break;
                case "KPIFormula":
                    KPI = KPI.OrderByDescending(kpi => kpi.KPIFormula);
                    break;     
                default:
                    KPI = KPI.OrderByDescending(kpi => kpi.KPIName);
                    break;
            }            
            //return View(db.TBKPICalculation.ToList());
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(KPI.ToPagedList(No_Of_Page, Size_Of_Page));            
        }

        // GET: /KPI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPICal kpical = db.TBKPICalculation.Find(id);
            if (kpical == null)
            {
                return HttpNotFound();
            }
            return View(kpical);
        }

        // GET: /KPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /KPI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="KPICalculationId,ReportGroupID,KPIName,KPINameDesc,KPIType,KPIFormula")] KPICal kpical)
        {
            if (ModelState.IsValid)
            {
                db.TBKPICalculation.Add(kpical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kpical);
        }

        // GET: /KPI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPICal kpical = db.TBKPICalculation.Find(id);
            if (kpical == null)
            {
                return HttpNotFound();
            }
            return View(kpical);
        }

        // POST: /KPI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="KPICalculationId,ReportGroupID,KPIName,KPINameDesc,KPIType,KPIFormula")] KPICal kpical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kpical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kpical);
        }

        // GET: /KPI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPICal kpical = db.TBKPICalculation.Find(id);
            if (kpical == null)
            {
                return HttpNotFound();
            }
            return View(kpical);
        }

        // POST: /KPI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KPICal kpical = db.TBKPICalculation.Find(id);
            db.TBKPICalculation.Remove(kpical);
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

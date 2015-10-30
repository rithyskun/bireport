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
    public class BoardTypeController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /BoardType/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "BoardType" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "LogicalFunctionType" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.FilterValue = Search_Data;

            var boardtype = from btype in db.TBBoardType select btype;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                boardtype = boardtype.Where(btype => btype.Boardtype.ToUpper().Contains(Search_Data.ToUpper())
                    || btype.LogicalFunctionType.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "BoardType":
                    boardtype = boardtype.OrderByDescending(btype => btype.BoardTypeId);
                    break;
                case "LogicalFunctionType":
                    boardtype = boardtype.OrderByDescending(btype => btype.LogicalFunctionType);
                    break;
                default:
                    boardtype = boardtype.OrderBy(btype => btype.BoardTypeId);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(boardtype.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.TBBoardType.ToList());
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

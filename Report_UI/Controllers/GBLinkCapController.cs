﻿using System;
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
    public class GBLinkCapController : Controller
    {
        private ReportIdentity db = new ReportIdentity();

        // GET: /GBLinkCap/
        public ActionResult Index()
        {
            return View(db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.ToList());
        }

        // GET: /GBLinkCap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataComGBLinkCap datacomgblinkcap = db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.Find(id);
            if (datacomgblinkcap == null)
            {
                return HttpNotFound();
            }
            return View(datacomgblinkcap);
        }

        // GET: /GBLinkCap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GBLinkCap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,BSCName,GBLinkCapacity,BeginDate,EndDate")] DataComGBLinkCap datacomgblinkcap)
        {
            if (ModelState.IsValid)
            {
                db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.Add(datacomgblinkcap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datacomgblinkcap);
        }

        // GET: /GBLinkCap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataComGBLinkCap datacomgblinkcap = db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.Find(id);
            if (datacomgblinkcap == null)
            {
                return HttpNotFound();
            }
            return View(datacomgblinkcap);
        }

        // POST: /GBLinkCap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,BSCName,GBLinkCapacity,BeginDate,EndDate")] DataComGBLinkCap datacomgblinkcap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datacomgblinkcap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datacomgblinkcap);
        }

        // GET: /GBLinkCap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataComGBLinkCap datacomgblinkcap = db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.Find(id);
            if (datacomgblinkcap == null)
            {
                return HttpNotFound();
            }
            return View(datacomgblinkcap);
        }

        // POST: /GBLinkCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataComGBLinkCap datacomgblinkcap = db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.Find(id);
            db.tbNSS_PSDatacom_BSC_GBLinkCapacityTransmission.Remove(datacomgblinkcap);
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

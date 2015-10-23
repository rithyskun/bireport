using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Report_UI.Models;
using System.Data.Entity;
using System.IO;
using Report_UI.DataContexts;
using Report_DO;
using System.Data.SqlClient;
using System.Web.Services.Description;



namespace Report_UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ReportIdentity db = new ReportIdentity();
        public ActionResult Operation()
        {           

          return View();        
        }

        public ActionResult System()
        {

            return View();
        }
        public ActionResult Index(string selectedRow)
        {
           
            return View(db.TBMasterReportList.ToList());
        }

        public ActionResult Schedule()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Reference()
        {
            ViewBag.Message = "Your Reference page.";

            return View();
        }        
        public ActionResult Dashboard()
        {
        
            ViewBag.Message = "Your dashboard page";           

            return View();
        }
        
    }
}
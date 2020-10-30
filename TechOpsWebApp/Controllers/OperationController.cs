using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechOpsWebApp.Models;
using System.Data.Entity;
namespace TechOpsWebApp.Controllers
{
    public class OperationController : Controller
    {
        public ActionResult Index()
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Operations.ToList());
            }
        }
        public ActionResult Create(Operation operation)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    dbmodel.Operations.Add(operation);
                    dbmodel.SaveChanges();
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult details(int id)
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Operations.Where(x => x.OperationID == id).FirstOrDefault());
            }
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Operations.Where(x => x.OperationID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        // Post: /Team/edit/1
        public ActionResult edit(int id, Operation operation)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    dbmodel.Entry(operation).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Operations.Where(x => x.OperationID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult delete(int id, FormCollection collection)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    Operation operation = dbmodel.Operations.Where(x => x.OperationID == id).FirstOrDefault();
                    dbmodel.Operations.Remove(operation);
                    dbmodel.SaveChanges();
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechOpsWebApp.Models;
using System.Data.Entity;
namespace TechOpsWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Team/index
        public ActionResult Index()
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Accounts.ToList());
            }
        }
        public ActionResult Create(Account acount)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    dbmodel.Accounts.Add(acount);
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
                return View(dbmodel.Accounts.Where(x => x.AccountId == id).FirstOrDefault());
            }
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Accounts.Where(x => x.AccountId == id).FirstOrDefault());
            }
        }
        [HttpPost]
        // Post: /Team/edit/1
        public ActionResult edit(int id, Account account)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    dbmodel.Entry(account).State = EntityState.Modified;
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
                return View(dbmodel.Accounts.Where(x => x.AccountId == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult delete(int id, FormCollection collection)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    Account account = dbmodel.Accounts.Where(x => x.AccountId == id).FirstOrDefault();
                    dbmodel.Accounts.Remove(account);
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
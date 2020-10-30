using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechOpsWebApp.Models;
namespace TechOpsWebApp.Controllers
{
    public class TeamController : Controller
    {
        // GET: /Team/index
        public ActionResult Index()
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Teams.ToList());
            }
        }
        // GET: /Team/create
        public ActionResult Create(Team member)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    dbmodel.Teams.Add(member);
                    dbmodel.SaveChanges();
                }
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }

        }
        // GET: /Team/ID/1
        public ActionResult details(int id)
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Teams.Where(x => x.UserID == id).FirstOrDefault());
            }
        }
        // GET: /Team/edit/1
        [HttpGet]
        public ActionResult edit(int id)
        {
            using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
            {
                return View(dbmodel.Teams.Where(x => x.UserID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        // Post: /Team/edit/1
        public ActionResult edit(int id, Team member)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    dbmodel.Entry(member).State = EntityState.Modified;
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
                return View(dbmodel.Teams.Where(x => x.UserID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult delete(int id, FormCollection collection)
        {
            try
            {
                using (TechOpsDBEntities dbmodel = new TechOpsDBEntities())
                {
                    Team member = dbmodel.Teams.Where(x => x.UserID == id).FirstOrDefault();
                    dbmodel.Teams.Remove(member);
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
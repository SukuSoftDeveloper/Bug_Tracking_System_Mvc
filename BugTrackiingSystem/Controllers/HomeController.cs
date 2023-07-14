using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using BugTrackiingSystem.Models;


namespace BugTrackiingSystem.Controllers
{

    
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Main()
        {

            return View();
        }
       

        [Authorize(Roles = "Lead,Admin,Developer")]
        public ActionResult Index(int? search)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            if(search.HasValue)
            {
                
                return View(db.Bugs.Where(temp => temp.BugID.ToString().Contains(search.ToString())).ToList());
                ViewBag.search = search.Value;
            }
            else
            {
                return View(db.Bugs.ToList());
            }
          
          
         
        }

        [Authorize(Roles = "Lead,Admin,Developer")]
        public ActionResult Detail(long id)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            Bug p = db.Bugs.Where(temp => temp.BugID == id).FirstOrDefault();
            return View(p);
        }

        [Authorize(Roles = "Lead,Admin")]
        public ActionResult Create()
        {

            return View();
        }

        
        [HttpPost]
     
        public ActionResult Create(Bug b)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            db.Bugs.Add(b);
            db.SaveChanges();
            TempData["msg"] = "Issue/Bug Added Successfully.";
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Lead,Admin,Developer")]
        public ActionResult Update(long id)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            Bug extbug = db.Bugs.Where(temp => temp.BugID == id).FirstOrDefault();
            ViewBag.Bugs=db.Bugs.ToList();

            return View(extbug);
        }
        [HttpPost]
        public ActionResult Update(Bug b)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            Bug existingbug = db.Bugs.Where(temp => temp.BugID == b.BugID).FirstOrDefault();
            existingbug.Tracker = b.Tracker;
            existingbug.Subject = b.Subject;
            existingbug.Description = b.Description;
            existingbug.Status = b.Status;
            existingbug.StartDate = b.StartDate;
            existingbug.Priority = b.Priority;
            existingbug.DueDate = b.DueDate;
            existingbug.Assignee = b.Assignee;
            existingbug.EstimatedTime = b.EstimatedTime;
            existingbug.PercentageDone = b.PercentageDone;
            db.SaveChanges();
            return RedirectToAction("Index");
;    
        }


        [Authorize(Roles = "Lead,Admin")]
        public ActionResult Delete(long id)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            Bug extbug = db.Bugs.Where(temp => temp.BugID == id).FirstOrDefault();
            return View(extbug);
        }
        [HttpPost]
        public ActionResult Delete(long id, Bug b)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            Bug extbug = db.Bugs.Where(temp => temp.BugID == id).FirstOrDefault();
            db.Bugs.Remove(extbug);
            db.SaveChanges();
            TempData["msg"] = "Issue/Bug Deleted Successfully.";
            return RedirectToAction("Index");
        }       
    }
}
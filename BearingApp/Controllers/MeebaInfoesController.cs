using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BearingApp.Models;
using Newtonsoft.Json;

namespace BearingApp.Controllers
{
    public class MeebaInfoesController : Controller
    {
        private BearingAppContext db = new BearingAppContext();

        // GET: MeebaInfoes
        public ActionResult Index()
        {
            return View(db.MeebaInfoes.ToList());
        }

        // GET: MeebaInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeebaInfo meebaInfo = db.MeebaInfoes.Find(id);
            if (meebaInfo == null)
            {
                return HttpNotFound();
            }
            return View(meebaInfo);
        }

        // GET: MeebaInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeebaInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,itemName,category,pull,apptInt,workInt,socInt,evtInt,persInt,otherInt,innerInt,OuterInt")] MeebaInfo meebaInfo)
        {
            if (ModelState.IsValid)
            {
                db.MeebaInfoes.Add(meebaInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meebaInfo);
        }

        // GET: MeebaInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeebaInfo meebaInfo = db.MeebaInfoes.Find(id);
            if (meebaInfo == null)
            {
                return HttpNotFound();
            }
            return View(meebaInfo);
        }

        // POST: MeebaInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,itemName,category,pull,apptInt,workInt,socInt,evtInt,persInt,otherInt,innerInt,OuterInt")] MeebaInfo meebaInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meebaInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meebaInfo);
        }

        // GET: MeebaInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeebaInfo meebaInfo = db.MeebaInfoes.Find(id);
            if (meebaInfo == null)
            {
                return HttpNotFound();
            }
            return View(meebaInfo);
        }

        // POST: MeebaInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeebaInfo meebaInfo = db.MeebaInfoes.Find(id);
            db.MeebaInfoes.Remove(meebaInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PostEvent([Bind(Include = "ID,itemName,category,pull")]MeebaInfo meeba) 
        {
            switch (meeba.category)
            {
                case "Social":
                    meeba.socInt++;
                    break;

                case "Appointment":
                    meeba.apptInt++;
                    break;

                case "Work":
                    meeba.workInt++;
                    break;

                case "Events":
                    meeba.evtInt++;
                    break;

                case "Other":
                    meeba.otherInt++;
                    break;

                case "Personal":
                    meeba.persInt++;
                    break;

            }

            switch (meeba.pull)
            {
                case "Inner":
                    meeba.innerInt++;
                    meeba.OuterInt--;
                    break;

                case "Outer":
                    meeba.OuterInt++;
                    meeba.innerInt--;
                    break;
            }

            if (ModelState.IsValid)
            {
                db.MeebaInfoes.Add(meeba);
                db.SaveChanges();
            }
            return new JsonResult() { Data = JsonConvert.SerializeObject(meeba.ID), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

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

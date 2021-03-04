using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudDoctor;

namespace CrudDoctor.Controllers
{
    public class doctorsController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: doctors
        public ActionResult Index()
        {
            return View(db.TB_DOCTOR.ToList());
        }

        // GET: doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DOCTOR tB_DOCTOR = db.TB_DOCTOR.Find(id);
            if (tB_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tB_DOCTOR);
        }

        // GET: doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DOCTOR,DOCTORNAME,BORNDATE,LOCATIONDOCTOR,DESCRIPTION")] TB_DOCTOR tB_DOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.TB_DOCTOR.Add(tB_DOCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_DOCTOR);
        }

        // GET: doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DOCTOR tB_DOCTOR = db.TB_DOCTOR.Find(id);
            if (tB_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tB_DOCTOR);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DOCTOR,DOCTORNAME,BORNDATE,LOCATIONDOCTOR,DESCRIPTION")] TB_DOCTOR tB_DOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_DOCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_DOCTOR);
        }

        // GET: doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DOCTOR tB_DOCTOR = db.TB_DOCTOR.Find(id);
            if (tB_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tB_DOCTOR);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_DOCTOR tB_DOCTOR = db.TB_DOCTOR.Find(id);
            db.TB_DOCTOR.Remove(tB_DOCTOR);
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

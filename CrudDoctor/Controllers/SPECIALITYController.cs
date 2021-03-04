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
    public class SPECIALITYController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: SPECIALITY
        public ActionResult Index()
        {
            return View(db.TB_SPECIALITY.ToList());
        }

        // GET: SPECIALITY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SPECIALITY tB_SPECIALITY = db.TB_SPECIALITY.Find(id);
            if (tB_SPECIALITY == null)
            {
                return HttpNotFound();
            }
            return View(tB_SPECIALITY);
        }

        // GET: SPECIALITY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPECIALITY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPECIALITY,DESCR_SPECIALITY")] TB_SPECIALITY tB_SPECIALITY)
        {
            if (ModelState.IsValid)
            {
                db.TB_SPECIALITY.Add(tB_SPECIALITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_SPECIALITY);
        }

        // GET: SPECIALITY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SPECIALITY tB_SPECIALITY = db.TB_SPECIALITY.Find(id);
            if (tB_SPECIALITY == null)
            {
                return HttpNotFound();
            }
            return View(tB_SPECIALITY);
        }

        // POST: SPECIALITY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPECIALITY,DESCR_SPECIALITY")] TB_SPECIALITY tB_SPECIALITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_SPECIALITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_SPECIALITY);
        }

        // GET: SPECIALITY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SPECIALITY tB_SPECIALITY = db.TB_SPECIALITY.Find(id);
            if (tB_SPECIALITY == null)
            {
                return HttpNotFound();
            }
            return View(tB_SPECIALITY);
        }

        // POST: SPECIALITY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_SPECIALITY tB_SPECIALITY = db.TB_SPECIALITY.Find(id);
            db.TB_SPECIALITY.Remove(tB_SPECIALITY);
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

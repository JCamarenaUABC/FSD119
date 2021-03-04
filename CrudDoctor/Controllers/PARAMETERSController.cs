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
    public class PARAMETERSController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: PARAMETERS
        public ActionResult Index()
        {
            return View(db.TB_PARAMETERS.ToList());
        }

        // GET: PARAMETERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PARAMETERS tB_PARAMETERS = db.TB_PARAMETERS.Find(id);
            if (tB_PARAMETERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_PARAMETERS);
        }

        // GET: PARAMETERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PARAMETERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PARAM,DESCR_PARAM,VAL1,VAL2,VAL3")] TB_PARAMETERS tB_PARAMETERS)
        {
            if (ModelState.IsValid)
            {
                db.TB_PARAMETERS.Add(tB_PARAMETERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_PARAMETERS);
        }

        // GET: PARAMETERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PARAMETERS tB_PARAMETERS = db.TB_PARAMETERS.Find(id);
            if (tB_PARAMETERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_PARAMETERS);
        }

        // POST: PARAMETERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PARAM,DESCR_PARAM,VAL1,VAL2,VAL3")] TB_PARAMETERS tB_PARAMETERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PARAMETERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_PARAMETERS);
        }

        // GET: PARAMETERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PARAMETERS tB_PARAMETERS = db.TB_PARAMETERS.Find(id);
            if (tB_PARAMETERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_PARAMETERS);
        }

        // POST: PARAMETERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PARAMETERS tB_PARAMETERS = db.TB_PARAMETERS.Find(id);
            db.TB_PARAMETERS.Remove(tB_PARAMETERS);
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

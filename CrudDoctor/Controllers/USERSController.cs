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
    public class USERSController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: USERS
        public ActionResult Index()
        {
            return View(db.TB_USERS.ToList());
        }

        // GET: USERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USERS tB_USERS = db.TB_USERS.Find(id);
            if (tB_USERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_USERS);
        }

        // GET: USERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USER,USERNAME,USERPASSWORD,BORNDATE,USEREMAIL")] TB_USERS tB_USERS)
        {
            if (ModelState.IsValid)
            {
                db.TB_USERS.Add(tB_USERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_USERS);
        }

        // GET: USERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USERS tB_USERS = db.TB_USERS.Find(id);
            if (tB_USERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_USERS);
        }

        // POST: USERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USER,USERNAME,USERPASSWORD,BORNDATE,USEREMAIL")] TB_USERS tB_USERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_USERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_USERS);
        }

        // GET: USERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USERS tB_USERS = db.TB_USERS.Find(id);
            if (tB_USERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_USERS);
        }

        // POST: USERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_USERS tB_USERS = db.TB_USERS.Find(id);
            db.TB_USERS.Remove(tB_USERS);
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

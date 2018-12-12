using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FooDo2.Models;

namespace FooDo2.Controllers
{
    public class TablesController : Controller
    {
        private QFoodDBEntitiesFooDo db = new QFoodDBEntitiesFooDo();

        // GET: tables
        public ActionResult TableIndex()
        {
            return View(db.tables.ToList());
        }

        // GET: tables/Details/5
        public ActionResult TableDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = from c in db.orders where c.idTable == id select c;
            return View(result.ToList());
        }

        // GET: tables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,positionX,positionY,number,size")] table table)
        {
            if (ModelState.IsValid)
            {
                db.tables.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table);
        }

        public ActionResult EditPosition(int id, int x , int y)
        {
  
            table tableEdit = db.tables.Find(id);
            tableEdit.positionX = x;
            tableEdit.positionY = y;
       
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: tables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table table = db.tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: tables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,positionX,positionY,number,size")] table table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        // GET: tables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table table = db.tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table table = db.tables.Find(id);
            db.tables.Remove(table);
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

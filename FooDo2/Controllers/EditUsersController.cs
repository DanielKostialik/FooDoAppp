using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FooDo2.Models;

namespace FooDo.Controllers
{
    public class EditUsersController : Controller
    {
        private QFoodDBEntitiesFooDo db = new QFoodDBEntitiesFooDo();
        public ActionResult Index(FooDo2.Models.user Model)
        {
            var db = new QFoodDBEntitiesFooDo();
            var users = db.users;
            return View(users.ToList());
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var db = new QFoodDBEntitiesFooDo();
            var users = db.users;
            var user = db.users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Submit(int? id)
        {

            var db = new QFoodDBEntitiesFooDo();

            var userUpdate = db.users.Find(id);
            if (TryUpdateModel(userUpdate, "", new string[] { "login","name", "surname", "password", "manager" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return RedirectToAction("Index", "EditUsers");
        }

        public ActionResult Delete(int? id)
        {



            var itemToRemove = db.users.SingleOrDefault(x => x.ID == id); //returns a single item.
            if (itemToRemove != null)
            {
                db.users.Remove(itemToRemove);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Add(FooDo2.Models.user Model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubmit(user userM)
        {
            db.users.Add(userM);
            db.SaveChanges();
            return RedirectToAction("Index", "EditUsers");
        }



    }
}
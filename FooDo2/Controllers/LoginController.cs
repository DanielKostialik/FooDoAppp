using System;
using FooDo2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FooDo2.Controllers
{
    public class LoginController : Controller
    {

        private QFoodDBEntitiesFooDo db = new QFoodDBEntitiesFooDo();
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(FooDo2.Models.user Model1)
        {       
            var userDetails = db.users.Where(x => x.login == Model1.login && x.password == Model1.password).FirstOrDefault();

            if (userDetails == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["userManager"] = userDetails.manager;
                Session["userID"] = userDetails.ID;             
                if (userDetails.manager == 1)
                    return RedirectToAction("IndexManager", "Home");
                else
                    return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
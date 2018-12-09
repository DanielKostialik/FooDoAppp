using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FooDo2.Models;

namespace FooDo.Controllers
{
    public class ConfigurationController : Controller
    {
        private QFoodDBEntitiesFooDo db = new QFoodDBEntitiesFooDo();
        public ActionResult Index()
        {
            //var tables = db.tables;
            //return View(tables.ToList());
            return View();  
        }
    }
}
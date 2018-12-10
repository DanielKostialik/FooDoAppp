using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FooDo2.Models;

namespace FooDo.Controllers
{
    public class OrderFoodController : Controller
    {
        private QFoodDBEntitiesFooDo db = new QFoodDBEntitiesFooDo();
        /*
                // GET: orderFoods
                public ActionResult Index()
                {
                    var orders = db.orders.Include(o => o.user).Include(o => o.user1);
                    return View(orders.ToList());
                }
        */

        /*  
       public ActionResult Index(string sortOrder)
       {
           ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
           var orders = db.orders.Include(o => o.user).Include(o => o.user1);
           switch (sortOrder)
           {
               case "name_desc":
                   orders = orders.OrderByDescending(s => s.ID);
                   break;
               case "Date":
                   orders = orders.OrderBy(s => s.timeOpen);
                   break;
               case "date_desc":
                   orders = orders.OrderByDescending(s => s.timeOpen);
                   break;
               default:
                   orders = orders.OrderBy(s => s.ID);
                   break;
           }
           return View(orders.ToList());
       }
       */

        public ActionResult Index(DateTime? start, DateTime? end)
        {

            if (start == null || end == null)
            {
                start = DateTime.Now.AddMonths(-3);
                ViewBag.open = start;

                end = DateTime.Today;
                ViewBag.close = end;
            }
            else
            {
                ViewBag.open = start;
                ViewBag.close = end;
            }

            var orders = db.orders.Where(x => x.timeOpen <= end && x.timeOpen >= start).ToList();

            
            return View(orders);
        }


        // GET: orderFoods/Details/5
        public ActionResult Details(int? id)
        {
            var idOrder = id;
            ViewData["idOrder"] = idOrder;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = from c in db.orderFoods where c.idOrder == id select c;
           
            return View(result.ToList());
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.idUserOpen = new SelectList(db.users, "ID", "name");
            ViewBag.idUserClose = new SelectList(db.users, "ID", "name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,idTable,idUserOpen,idUserClose,timeOpen,timeClose,details")] order order)
        {
            if (ModelState.IsValid)
            {
                order.totalPrice = 0;
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUserOpen = new SelectList(db.users, "ID", "name", order.idUserOpen);
            ViewBag.idUserClose = new SelectList(db.users, "ID", "name", order.idUserClose);

            return View(order);
        }

        // GET: testtt/Create
        public ActionResult AddFood(int? id)
        {
            ViewBag.idFood = new SelectList(db.food, "ID", "name");
            ViewBag.idTest = id;
            return View();
        }

        // POST: testtt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFood(int idOrder, int idFood)
        {

            // add food price to total price in order
            food foodC = db.food.Find(idFood);
            order orderC = db.orders.Find(idOrder);
            orderC.totalPrice = orderC.totalPrice + foodC.price;

            orderFood oFood = new orderFood();
            oFood.idOrder = idOrder;
            oFood.idFood = idFood;
            db.orderFoods.Add(oFood);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = idOrder });
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUserOpen = new SelectList(db.users, "ID", "name", order.idUserOpen);
            ViewBag.idUserClose = new SelectList(db.users, "ID", "name", order.idUserClose);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,idTable,idUserOpen,idUserClose,timeOpen,timeClose,details")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUserOpen = new SelectList(db.users, "ID", "name", order.idUserOpen);
            ViewBag.idUserClose = new SelectList(db.users, "ID", "name", order.idUserClose);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
           
            // Delete constrains
            //var ordersFoodToDelete = from c in db.orderFoods where c.idOrder == id  c;

            db.orderFoods.RemoveRange(db.orderFoods.Where(x => x.idOrder == id));
            db.orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFood(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderFood oFood = db.orderFoods.Find(id);
            if (oFood == null)
            {
                return HttpNotFound();
            }
            return View(oFood);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteFood")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFood(int id)
        {

            orderFood oFood = db.orderFoods.Find(id);
            int idOrder = oFood.idOrder;
            int idFood = oFood.idFood;


            food foodC = db.food.Find(idFood);
            order orderC = db.orders.Find(idOrder);
            orderC.totalPrice = orderC.totalPrice - foodC.price;



            db.orderFoods.Remove(oFood);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = idOrder });
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyFood.Data;
using EasyFood.Data.Repositories.GenericResository;

namespace WebApplication1.Controllers
{
    public class DishRestController : Controller
    {
        private IGenericRepository<dish_restaurant> dishrestRepository;
        private IGenericRepository<dish> dishRepository;
        private IGenericRepository<restaurant> restaurantRepository;

        public DishRestController(IGenericRepository<dish_restaurant> dishrestRepository,
            IGenericRepository<dish> dishRepository,
            IGenericRepository<restaurant> restaurantRepository)
        {
            this.dishrestRepository = dishrestRepository;
            this.dishRepository = dishRepository;
            this.restaurantRepository = restaurantRepository;
        }
 


        // GET: /DishRest/
        public ActionResult Index()
        {
            var dish_restaurant = dishrestRepository.GetAll().ToList();
            return View(dish_restaurant.ToList());
        }

        // GET: /DishRest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dish_restaurant dish_restaurant = dishrestRepository.GetSingleBy(x => x.id_dishrest == id);
            if (dish_restaurant == null)
            {
                return HttpNotFound();
            }
            return View(dish_restaurant);
        }

        // GET: /DishRest/Create
        public ActionResult Create()
        {
            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish");
            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant");
            return View();
        }

        // POST: /DishRest/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_dishrest,id_dish,id_restaurant")] dish_restaurant dish_restaurant)
        {
            if (ModelState.IsValid)
            {
                dishrestRepository.Add(dish_restaurant);
                dishrestRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish");
            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant");
            return View(dish_restaurant);
        }

        // GET: /DishRest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dish_restaurant dish_restaurant = dishrestRepository.GetSingleBy(x => x.id_dishrest == id);
            if (dish_restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish");
            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant");
            return View(dish_restaurant);
        }

        // POST: /DishRest/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_dishrest,id_dish,id_restaurant")] dish_restaurant dish_restaurant)
        {
            if (ModelState.IsValid)
            {
               dishrestRepository.Edit(dish_restaurant);
                return RedirectToAction("Index");
            }
            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish");
            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant");
            return View(dish_restaurant);
        }

        // GET: /DishRest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dish_restaurant dish_restaurant = dishrestRepository.GetSingleBy(x => x.id_dishrest == id);
            if (dish_restaurant == null)
            {
                return HttpNotFound();
            }
            return View(dish_restaurant);
        }

        // POST: /DishRest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dish_restaurant dish_restaurant = dishrestRepository.GetSingleBy(x => x.id_dishrest == id);
            dishrestRepository.Remove(dish_restaurant);
            dishrestRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dishrestRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

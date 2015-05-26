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
    public class DishController : Controller
    {
        private IGenericRepository<dish> dishRepository;
        private IGenericRepository<cuisine> cuisineRepository;

        public DishController(IGenericRepository<dish> dishRepository, IGenericRepository<cuisine> cuisineRepository)
        {
            this.dishRepository = dishRepository;
            this.cuisineRepository = cuisineRepository;

        }

        // GET: /Dish/
        public ActionResult Index()
        {
            var dishes = dishRepository.GetAll();
            return View(dishes.ToList());
        }

        // GET: /Dish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dish dish = dishRepository.GetSingleBy(x=>x.id_dish==id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // GET: /Dish/Create
        public ActionResult Create()
        {
            ViewBag.id_cuisine = new SelectList(cuisineRepository.GetAll().ToList(), "id_cuisine", "name_cuisine");
            return View();
        }

        // POST: /Dish/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_dish,name_dish,weight,price,description,id_cuisine")] dish dish)
        {
            if (ModelState.IsValid)
            {
                dishRepository.Add(dish);
                dishRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.id_cuisine = new SelectList(cuisineRepository.GetAll().ToList(), "id_cuisine", "name_cuisine", dish.id_cuisine);
            return View(dish);
        }

        // GET: /Dish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dish dish = dishRepository.GetSingleBy(x => x.id_dish == id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cuisine = new SelectList(cuisineRepository.GetAll().ToList(), "id_cuisine", "name_cuisine", dish.id_cuisine);
            return View(dish);
        }

        // POST: /Dish/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_dish,name_dish,weight,price,description,id_cuisine")] dish dish)
        {
            if (ModelState.IsValid)
            {
                dishRepository.Edit(dish);
                dishRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.id_cuisine = new SelectList(cuisineRepository.GetAll().ToList(), "id_cuisine", "name_cuisine", dish.id_cuisine);
            return View(dish);
        }

        // GET: /Dish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dish dish = dishRepository.GetSingleBy(x => x.id_dish == id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // POST: /Dish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dish dish = dishRepository.GetSingleBy(x => x.id_dish == id);
            dishRepository.Remove(dish);
            dishRepository .Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dishRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

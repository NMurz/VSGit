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
    public class RestaurantController : Controller
    {

        private IGenericRepository<restaurant> restaurantRepository;

        public RestaurantController(IGenericRepository<restaurant> restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        // GET: /Restaurant/
        public ActionResult Index()
        {
            return View(restaurantRepository.GetAll().ToList());
        }

        // GET: /Restaurant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurant restaurant = restaurantRepository.GetSingleBy(x => x.id_restaurant == id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: /Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Restaurant/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_restaurant,name_restaurant,address,description")] restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantRepository.Add(restaurant);
                restaurantRepository.Save();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: /Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurant restaurant = restaurantRepository.GetSingleBy(x=>x.id_restaurant==id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: /Restaurant/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_restaurant,name_restaurant,address,description")] restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantRepository.Edit(restaurant);
                restaurantRepository.Save();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: /Restaurant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurant restaurant = restaurantRepository.GetSingleBy(x=>x.id_restaurant==id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: /Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            restaurant restaurant = restaurantRepository.GetSingleBy(x=>x.id_restaurant==id);
            restaurantRepository.Remove(restaurant);
            restaurantRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                restaurantRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

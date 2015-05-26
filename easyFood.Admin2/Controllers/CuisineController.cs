using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyFood.Data;
using EasyFood.Data.Repositories;
using EasyFood.Data.Repositories.GenericResository;

namespace WebApplication1.Controllers
{
    public class CuisineController : Controller
    {
        private IGenericRepository<cuisine> CuisineRepository { get; set; }

        public CuisineController(IGenericRepository<cuisine> cuisineRepository)
        {
            CuisineRepository = cuisineRepository;
        }

        // GET: /Cuisine/
        public ActionResult Index()
        {
            var cusines = CuisineRepository.GetAll().ToList();
            return View(cusines);
        }

        // GET: /Cuisine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuisine cuisine = CuisineRepository.GetSingleBy(x=>x.id_cuisine==id);
            if (cuisine == null)
            {
                return HttpNotFound();
            }
            return View(cuisine);
        }

        // GET: /Cuisine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cuisine/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_cuisine,name_cuisine")] cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                CuisineRepository.Add(cuisine);
                CuisineRepository.Save();
                return RedirectToAction("Index");
            }

            return View(cuisine);
        }

        // GET: /Cuisine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuisine cuisine = CuisineRepository.GetSingleBy(x=>x.id_cuisine==id);
            if (cuisine == null)
            {
                return HttpNotFound();
            }
            return View(cuisine);
        }

        // POST: /Cuisine/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_cuisine,name_cuisine")] cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                CuisineRepository.Edit(cuisine);
                CuisineRepository.Save();
                return RedirectToAction("Index");
            }
            return View(cuisine);
        }

        // GET: /Cuisine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuisine cuisine = CuisineRepository.GetSingleBy(x=>x.id_cuisine==id);
            CuisineRepository.Remove(cuisine);
            if (cuisine == null)
            {
                return HttpNotFound();
            }
            return View(cuisine);
        }

        // POST: /Cuisine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuisine cuisine = CuisineRepository.GetSingleBy(x=>x.id_cuisine==id);
            CuisineRepository.Remove(cuisine);
            CuisineRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CuisineRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

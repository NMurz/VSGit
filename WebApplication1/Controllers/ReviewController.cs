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
    public class ReviewController : Controller
    {
        private IGenericRepository<review> reviewRepository;
        private IGenericRepository<restaurant> restaurantRepository; 

        public ReviewController(IGenericRepository<review> reviewRepository, IGenericRepository<restaurant> restaurantRepository)
        {
            this.reviewRepository = reviewRepository;
            this.restaurantRepository = restaurantRepository;
        }

        // GET: /Review/
        public ActionResult Index()
        {
            var reviews = reviewRepository.GetAll();
            return View(reviews.ToList());
        }

        // GET: /Review/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = reviewRepository.GetSingleBy(x => x.id_review == id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: /Review/Create
        public ActionResult Create()
        {
            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant");
            return View();
        }

        // POST: /Review/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_review,rating,comment,id_restaurant")] review review)
        {
            if (ModelState.IsValid)
            {
                reviewRepository.Add(review);
                reviewRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant", review.id_restaurant);
            return View(review);
        }

        // GET: /Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = reviewRepository.GetSingleBy(x => x.id_review == id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_restaurant = new SelectList(restaurantRepository.GetAll().ToList(), "id_restaurant", "name_restaurant", review.id_restaurant);
            return View(review);
        }

        // POST: /Review/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_review,rating,comment,id_restaurant")] review review)
        {
            if (ModelState.IsValid)
            {
                reviewRepository.Edit(review);
                reviewRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.id_restaurant = new SelectList(reviewRepository.GetAll().ToList(), "id_restaurant", "name_restaurant", review.id_restaurant);
            return View(review);
        }

        // GET: /Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = reviewRepository.GetSingleBy(x => x.id_review == id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: /Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            review review = reviewRepository.GetSingleBy(x => x.id_review == id);
            reviewRepository.Remove(review);
            reviewRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                reviewRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

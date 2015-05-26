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
    public class OrderController : Controller
    {
        private IGenericRepository<order> orderRepository;
        private IGenericRepository<AspNetUser> aspnetuserRepository; 

        public OrderController(IGenericRepository<order> orderRepository, IGenericRepository<AspNetUser> aspnetuserRepository)
        {
            this.orderRepository = orderRepository;
            this.aspnetuserRepository = aspnetuserRepository;
        }

        // GET: /Order/
        public ActionResult Index()
        {
            var orders = orderRepository.GetAll();
            return View(orders.ToList());
        }

        // GET: /Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = orderRepository.GetSingleBy(x => x.id_order == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: /Order/Create
        public ActionResult Create()
        {
            ViewBag.id_aspnet_user = new SelectList(aspnetuserRepository.GetAll().ToList(), "Id", "UserName");
            return View();
        }

        // POST: /Order/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_order,id_aspnet_user,create_date")] order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.Add(order);
                orderRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.id_aspnet_user = new SelectList(aspnetuserRepository.GetAll().ToList(), "Id", "UserName", order.id_aspnet_user);
            return View(order);
        }

        // GET: /Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = orderRepository.GetSingleBy(x => x.id_order == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aspnet_user = new SelectList(aspnetuserRepository.GetAll().ToList(), "Id", "UserName", order.id_aspnet_user);
            return View(order);
        }

        // POST: /Order/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_order,id_aspnet_user,create_date")] order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.Edit(order);
                orderRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.id_aspnet_user = new SelectList(aspnetuserRepository.GetAll().ToList(), "Id", "UserName", order.id_aspnet_user);
            return View(order);
        }

        // GET: /Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = orderRepository.GetSingleBy(x => x.id_order == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = orderRepository.GetSingleBy(x => x.id_order == id);
            orderRepository.Remove(order);
            orderRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                orderRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

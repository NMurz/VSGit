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
    public class OrderItemsController : Controller
    {
        private IGenericRepository<order_items> orderitemsRepository;
        private IGenericRepository<dish> dishRepository;
        private IGenericRepository<order> orderRepository; 

        public OrderItemsController(IGenericRepository<order_items> orderitemsRepository, IGenericRepository<dish> dishRepository,
            IGenericRepository<order> orderRepository)
        {
            this.orderitemsRepository = orderitemsRepository;
            this.dishRepository = dishRepository;
            this.orderRepository = orderRepository;
        }

        // GET: /OrderItems/
        public ActionResult Index()
        {
            var order_items = orderitemsRepository.GetAll();
            return View(order_items.ToList());
        }

        // GET: /OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = orderitemsRepository.GetSingleBy(x => x.id_orderitems == id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // GET: /OrderItems/Create
        public ActionResult Create()
        {
            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish");
            ViewBag.id_order = new SelectList(orderRepository.GetAll().ToList(), "id_order", "id_aspnet_user");
            return View();
        }

        // POST: /OrderItems/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_order,id_dish,quantity")] order_items order_items)
        {
            if (ModelState.IsValid)
            {
                orderitemsRepository.Add(order_items);
                orderitemsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish", order_items.id_dish);
            ViewBag.id_order = new SelectList(orderRepository.GetAll().ToList(), "id_order", "id_aspnet_user", order_items.id_order);
            return View(order_items);
        }

        // GET: /OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = orderitemsRepository.GetSingleBy(x => x.id_orderitems == id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish", order_items.id_dish);
            ViewBag.id_order = new SelectList(orderRepository.GetAll().ToList(), "id_order", "id_aspnet_user", order_items.id_order);
            return View(order_items);
        }

        // POST: /OrderItems/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_order,id_dish,quantity")] order_items order_items)
        {
            if (ModelState.IsValid)
            {
                orderitemsRepository.Edit(order_items);
                orderitemsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.id_dish = new SelectList(dishRepository.GetAll().ToList(), "id_dish", "name_dish", order_items.id_dish);
            ViewBag.id_order = new SelectList(orderRepository.GetAll().ToList(), "id_order", "id_aspnet_user", order_items.id_order);
            return View(order_items);
        }

        // GET: /OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = orderitemsRepository.GetSingleBy(x => x.id_orderitems == id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // POST: /OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_items order_items = orderitemsRepository.GetSingleBy(x => x.id_orderitems == id);
            orderitemsRepository.Remove(order_items);
            orderitemsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                orderitemsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

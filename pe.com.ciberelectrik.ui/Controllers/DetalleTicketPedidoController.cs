using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pe.com.ciberelectrik.ui.Models;
using pe.com.ciberelectrik.ui.Models.db;

namespace pe.com.ciberelectrik.ui.Controllers
{
    public class DetalleTicketPedidoController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: DetalleTicketPedido
        public ActionResult Index()
        {
            var detalleticketpedido = db.detalleticketpedido.Include(d => d.producto).Include(d => d.ticketpedido);
            return View(detalleticketpedido.ToList());
        }

        // GET: DetalleTicketPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleTicketPedido detalleTicketPedido = db.detalleticketpedido.Find(id);
            if (detalleTicketPedido == null)
            {
                return HttpNotFound();
            }
            return View(detalleTicketPedido);
        }

        // GET: DetalleTicketPedido/Create
        public ActionResult Create()
        {
            ViewBag.codpro = new SelectList(db.producto, "codigo", "nombre");
            ViewBag.nroped = new SelectList(db.ticketpedido, "numero", "numero");
            return View();
        }

        // POST: DetalleTicketPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero,cantidad,precio,nroped,codpro")] DetalleTicketPedido detalleTicketPedido)
        {
            if (ModelState.IsValid)
            {
                db.detalleticketpedido.Add(detalleTicketPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codpro = new SelectList(db.producto, "codigo", "nombre", detalleTicketPedido.codpro);
            ViewBag.nroped = new SelectList(db.ticketpedido, "numero", "numero", detalleTicketPedido.nroped);
            return View(detalleTicketPedido);
        }

        // GET: DetalleTicketPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleTicketPedido detalleTicketPedido = db.detalleticketpedido.Find(id);
            if (detalleTicketPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codpro = new SelectList(db.producto, "codigo", "nombre", detalleTicketPedido.codpro);
            ViewBag.nroped = new SelectList(db.ticketpedido, "numero", "numero", detalleTicketPedido.nroped);
            return View(detalleTicketPedido);
        }

        // POST: DetalleTicketPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero,cantidad,precio,nroped,codpro")] DetalleTicketPedido detalleTicketPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleTicketPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codpro = new SelectList(db.producto, "codigo", "nombre", detalleTicketPedido.codpro);
            ViewBag.nroped = new SelectList(db.ticketpedido, "numero", "numero", detalleTicketPedido.nroped);
            return View(detalleTicketPedido);
        }

        // GET: DetalleTicketPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleTicketPedido detalleTicketPedido = db.detalleticketpedido.Find(id);
            if (detalleTicketPedido == null)
            {
                return HttpNotFound();
            }
            return View(detalleTicketPedido);
        }

        // POST: DetalleTicketPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleTicketPedido detalleTicketPedido = db.detalleticketpedido.Find(id);
            db.detalleticketpedido.Remove(detalleTicketPedido);
            db.SaveChanges();
            return RedirectToAction("Index");
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

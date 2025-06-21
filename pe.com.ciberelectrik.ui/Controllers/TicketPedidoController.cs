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
    public class TicketPedidoController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: TicketPedido
        public ActionResult Index()
        {
            var ticketpedido = db.ticketpedido.Include(t => t.cliente).Include(t => t.empleado);
            return View(ticketpedido.ToList());
        }

        // GET: TicketPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketPedido ticketPedido = db.ticketpedido.Find(id);
            if (ticketPedido == null)
            {
                return HttpNotFound();
            }
            return View(ticketPedido);
        }

        // GET: TicketPedido/Create
        public ActionResult Create()
        {
            ViewBag.codcli = new SelectList(db.cliente, "codigo", "nombre");
            ViewBag.codemp = new SelectList(db.empleado, "codigo", "nombre");
            return View();
        }

        // POST: TicketPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero,fecha,codemp,codcli,estado")] TicketPedido ticketPedido)
        {
            if (ModelState.IsValid)
            {
                db.ticketpedido.Add(ticketPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codcli = new SelectList(db.cliente, "codigo", "nombre", ticketPedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado, "codigo", "nombre", ticketPedido.codemp);
            return View(ticketPedido);
        }

        // GET: TicketPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketPedido ticketPedido = db.ticketpedido.Find(id);
            if (ticketPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codcli = new SelectList(db.cliente, "codigo", "nombre", ticketPedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado, "codigo", "nombre", ticketPedido.codemp);
            return View(ticketPedido);
        }

        // POST: TicketPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero,fecha,codemp,codcli,estado")] TicketPedido ticketPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codcli = new SelectList(db.cliente, "codigo", "nombre", ticketPedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado, "codigo", "nombre", ticketPedido.codemp);
            return View(ticketPedido);
        }

        // GET: TicketPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketPedido ticketPedido = db.ticketpedido.Find(id);
            if (ticketPedido == null)
            {
                return HttpNotFound();
            }
            return View(ticketPedido);
        }

        // POST: TicketPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketPedido ticketpedido = db.ticketpedido.Find(id);
            if (ticketpedido != null)
            {
                //cambiamos el estado
                ticketpedido.estado = false;
                db.SaveChanges();
            }
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

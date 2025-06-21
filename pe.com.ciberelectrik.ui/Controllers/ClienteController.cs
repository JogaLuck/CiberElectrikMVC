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
    public class ClienteController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = db.cliente.Include(c => c.distrito).Include(c => c.TipoDocumento);
            return View(cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre");
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre");
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,apellidoPaterno,apellidoMaterno,documentoCliente,direccionCliente,telefonoCliente,celularCliente,correoCliente,estado,coddis,codtipd")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", cliente.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", cliente.codtipd);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", cliente.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", cliente.codtipd);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,apellidoPaterno,apellidoMaterno,documentoCliente,direccionCliente,telefonoCliente,celularCliente,correoCliente,estado,coddis,codtipd")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", cliente.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", cliente.codtipd);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.cliente.Find(id);
            if (cliente != null)
            {
                //cambiamos el estado
                cliente.estado = false;
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

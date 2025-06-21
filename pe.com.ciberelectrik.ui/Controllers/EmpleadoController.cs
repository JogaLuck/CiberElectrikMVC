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
    public class EmpleadoController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.distrito).Include(e => e.rol).Include(e => e.tipodocumento);
            return View(empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre");
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre");
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,apepaterno,apematerno,documento,direccion,telefono,celular,correo,usuario,clave,estado,coddis,codrol,codtipd")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", empleado.codtipd);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", empleado.codtipd);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,apepaterno,apematerno,documento,direccion,telefono,celular,correo,usuario,clave,estado,coddis,codrol,codtipd")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", empleado.codtipd);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.empleado.Find(id);
            if (empleado != null)
            {
                //cambiamos el estado
                empleado.estado = false;
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

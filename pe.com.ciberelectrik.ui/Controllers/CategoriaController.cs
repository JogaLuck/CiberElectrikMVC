using pe.com.ciberelectrik.ui.Models;
using pe.com.ciberelectrik.ui.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.ui.Controllers
{
    public class CategoriaController : Controller
    {
        //crear uun objeto del ApplicationDBContext
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET -> lo utilizamos para las rutas y algunas acciones
        //[HttpGet]
        public ActionResult Index()
        {
            return View(db.categoria.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }


        // POST -> para las acciones que son ejecutadas desde un boton
        [HttpPost]
        public ActionResult Create([Bind(Include = "codigo,nombre,estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "codigo,nombre,estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Categoria categoria = db.categoria.Find(id);
            //eliminamos fisica -> esto no se usa
            //db.categoria.Remove(categoria);
            //db.SaveChanges();
            if (categoria != null)
            {
                //cambiamos el estado
                categoria.estado = false;
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
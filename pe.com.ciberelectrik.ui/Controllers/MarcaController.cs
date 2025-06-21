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
    public class MarcaController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        // GET: Marca
        public ActionResult Index()
        {
            return View(db.marca.ToList());
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }


        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "codigo,nombre,estado")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                db.marca.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "codigo,nombre,estado")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Marca marca = db.marca.Find(id);
            if (marca != null)
            {
                //cambiamos el estado
                marca.estado = false;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.ui.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string clave)
        {
            if (usuario == "mhuapalla" && clave == "123456")
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.ErrorMessage = "Usuario o clave no valida";
            }
            return View();
        }
    }
}
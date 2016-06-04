using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarlOberstV2.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            //return View();
            return "Método indice de el controlador tienda";
        }

        public string Buscar(string genero)
        {
            //return View();
            string msg = HttpUtility.HtmlEncode("Tienda.Buscar, Genero = " + genero);
            return msg;
        }

        public string Detalles(int id)
        {
            //return View();
            return "Tienda.Detalles, ID = " + id;
        }
    }
}
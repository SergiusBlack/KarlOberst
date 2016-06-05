using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarlOberstV2.Models;

namespace KarlOberstV2.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var generos = new List<Genero>();
            generos.Add(new Genero { Nombre = "Salchichas" });
            generos.Add(new Genero { Nombre = "Fiambres" });
            generos.Add(new Genero { Nombre = "Otros" });

            return View(generos);
        }

        public ActionResult Buscar(string genero)
        {
            var genModel = new Genero { Nombre = genero };
            return View(genModel);

        }

        public ActionResult Detalles(int id)
        {
            var producto = new Producto { Nombre = "producto " + id };
            return View(producto);
        }
    }
}
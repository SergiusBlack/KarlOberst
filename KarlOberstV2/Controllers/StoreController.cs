using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarlOberstV2.Models;
using KarlOberstV2.DB;
using System.Configuration;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data;

namespace KarlOberstV2.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var con = new Conexiones();
            var tablaGeneros = con.GetGeneros();
            var generos = new List<Genero>();

            for(var i = 0; i< tablaGeneros.Rows.Count; i++)
            {
                generos.Add(new Genero { Nombre = tablaGeneros.Rows[i]["nombre"].ToString()
                                        , Descripcion = tablaGeneros.Rows[i]["descripcion"].ToString(),
                    img = tablaGeneros.Rows[i]["img"].ToString()
                });
            }
            return View(generos);
        }

        public ActionResult Buscar(string genero = "Salchichas")
        {

            var genModel = new Genero();
            var Gen = new Conexiones();
            genModel = Gen.GetGenByName(genero);
            
            return View(genModel);

        }

        public ActionResult Detalles(int id)
        {
            var conn = ConfigurationManager.ConnectionStrings["KarlOberstCS"].ConnectionString;
            var producto = new Producto { Nombre = "producto " + id };
            return View(producto);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarlOberstV2.DB;

namespace KarlOberstV2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return PartialView();
        }

        public void Add(int idProd, int cant)
        {

            Conexiones con = new Conexiones();
            //Obtenemos Producto de BD
            Models.Producto prod = con.GetProductById(idProd);

            //Rellenamos el objeto ItemCart con los datos del producto + la cantidad
            Models.ItemCart iC = new Models.ItemCart();
            iC.Cantidad = cant;
            iC.Descripcion = prod.Descripcion;
            iC.Genero = prod.Genero;
            iC.IdGenero = prod.IdGenero;
            iC.Precio = prod.Precio;
            iC.ImgProducto = prod.ImgProducto;

            //Registramos en BD

            

        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

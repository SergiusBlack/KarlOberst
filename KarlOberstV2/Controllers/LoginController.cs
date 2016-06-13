using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KarlOberstV2.Controllers
{

    public class LoginController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Models.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(usuario.EsValido(usuario.NombreUsuario, usuario.Password))
                {
                    FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, true);
                    //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, usuario.NombreUsuario, DateTime.Now,
                    //    DateTime.Now.AddDays(30),
                    //    true,
                    //    string.Empty);

                    //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    //System.Web.HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    //System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                        return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ModelState.AddModelError("", "¡Login incorrecto!");
                }
                
            }
            return View(usuario);
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Index", "Home");
        }

    }


}
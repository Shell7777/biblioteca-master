using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BibliotecaUPN.Web.Controllers
{
    public class AuthController : Controller
    {
        IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        public AuthController(){
            this.service = new AuthService();


        }
        [HttpGet]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var usuario = service.UsuarioFind(username, password);
            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Session["Usuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
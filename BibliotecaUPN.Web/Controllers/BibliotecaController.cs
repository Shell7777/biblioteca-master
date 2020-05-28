using BibliotecaUPN.Web.Constantes;
using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        IBibliotecaService bibliotecaService;
        public BibliotecaController(){
            this.bibliotecaService = new BibliotecaService();
        }
        public BibliotecaController(IBibliotecaService  service)
        {
            this.bibliotecaService = service;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Usuario user;
            try {
                user = (Usuario)Session["Usuario"];
            }
            catch ( Exception e) {
                user = new Usuario { Id = 1 }; 
            }

            var model = bibliotecaService.bibliotecaWithLibroUsuario(user.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user;
            try
            {
                user = (Usuario)Session["Usuario"];
            }
            catch (Exception e)
            {
                user = new Usuario { Id = 1 };
            }

            var biblioteca = new Biblioteca {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            bibliotecaService.BibliotecaAdd(biblioteca);

            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user;
            try
            {
                user = (Usuario)Session["Usuario"];
            }
            catch (Exception e)
            {
                user = new Usuario { Id = 1 };
            }

            var libro = bibliotecaService.BibliotecaFindLibroIdyUsuarioId(libroId, user.Id);

            libro.Estado = ESTADO.LEYENDO;
            bibliotecaService.SaveChanges();            

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user;
            try
            {
                user = (Usuario)Session["Usuario"];
            }
            catch (Exception e)
            {
                user = new Usuario { Id = 1 };
            }

            var libro = bibliotecaService.BibliotecaFindLibroIdyUsuarioId(libroId, user.Id);

            libro.Estado = ESTADO.TERMINADO;
            bibliotecaService.SaveChanges();

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }
    }
}
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
    public class LibroController : Controller
    {
        IserviceLibro iserviceLibro;
        IComentaioService comentaioService;
        public LibroController(){
            iserviceLibro = new LibroService();
            comentaioService = new ComentaioService();
        }
        public LibroController(IserviceLibro iservice) 
        {
            this.iserviceLibro = iservice;
        }
        public LibroController(IserviceLibro iservice, IComentaioService comentaioService)
        {
            this.iserviceLibro = iservice;
            this.comentaioService = comentaioService;
        }
        [HttpGet]
        public ActionResult Details(int id)
        { 
            return View(iserviceLibro.libroDetailsIncludeAutorComentarios(id));
        }

        [HttpPost]
        public ActionResult AddComentario(Comentario comentario)
        {
            // TO-DO validar que el usuario haya terminado de leer el libro para comentar.
            // caso contrario no dejar comentar.

            Usuario user;
            try { user = (Usuario)Session["Usuario"]; }
            catch (Exception e) {
                user = new Usuario { Id = 8 };
            }
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            comentaioService.Add(comentario);

            var libro = iserviceLibro.libroFind(comentario.Id);
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            iserviceLibro.saveChanges();

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }
    }
}
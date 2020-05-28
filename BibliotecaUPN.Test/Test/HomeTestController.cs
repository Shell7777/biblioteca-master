using BibliotecaUPN.Web.Controllers;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BibliotecaUPN.Test.Test
{
    [TestFixture]
    class HomeTestController
    {

        [Test]
        public void testIsnotNulModel()
        {
            var mock = new Mock<IserviceLibro>();
            mock.Setup(a => a.LibrosListIncludeAutor()).Returns(new List<Libro>());
            var controller = new HomeController(mock.Object);
            var view = controller.Index() as ViewResult;
            Assert.IsNotNull(view);
            Assert.IsInstanceOf<List<Libro>>(view.Model);
        }
    }
    [TestFixture]
    class LibroTestController
    {
        [Test]
        public void detailsIsnotNull()
        {

            var mock = new Mock<IserviceLibro>();
            mock.Setup(a => a.libroDetailsIncludeAutorComentarios(8))
                .Returns(new Libro
                {
                    Id = 8,
                    Nombre = "Harry Potter 2",
                    Autor = new Autor { Id = 5, Nombres = "JkRowling" }

                });
            var controller = new LibroController(mock.Object);
            var view = controller.Details(8) as ViewResult;
            Assert.IsNotNull(view);
            Assert.IsInstanceOf<Libro>(view.Model);
        }
        [Test]
        public void AddComentarioIsnotNull()
        {
            Comentario comentario = new Comentario {
                LibroId = 8,
                Puntaje = 2,
                Texto = "Estubo muy buena recomendado papu ",
                Id=8
            };
            var mockLibro = new Mock<IserviceLibro>();
            mockLibro.Setup(a => a.libroFind(8)).Returns(new Libro {Puntaje = 4 });
            mockLibro.Setup(a => a.saveChanges());
            var mockComents = new Mock<IComentaioService>();
            mockComents.Setup(a => a.Add(comentario));

            var controller = new LibroController(mockLibro.Object,mockComents.Object);
            var view = controller.AddComentario(comentario) as RedirectToRouteResult;
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
            Assert.IsNotNull(view);
        }
    }
    [TestFixture]
    class BibliotecaTestController {
        [Test]
        public void testIndexnotNull() {
            var mock = new Mock<IBibliotecaService>();
            mock.Setup(a => a.bibliotecaWithLibroUsuario(1)).Returns(new List<Biblioteca>() { 
                new Biblioteca (),new Biblioteca (),
            });
            var controller = new BibliotecaController(mock.Object);
            var view = controller.Index() as ViewResult;
            var modelo = (List<Biblioteca>)view.Model;
            Assert.AreEqual(modelo.Count, 2);
            Assert.IsInstanceOf<List<Biblioteca>>(view.Model);
            Assert.IsNotNull(view);
        }
        [Test]
        public void addnotNull()
        {
            var mock = new Mock<IBibliotecaService>();
            mock.Setup(a => a.BibliotecaAdd(new Biblioteca()));
            var controller = new BibliotecaController(mock.Object);
            var view = controller.Add(4) as RedirectToRouteResult;
            var valor = controller.TempData;
            Assert.IsNotNull(valor["SuccessMessage"]);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void MarcarComoLeyendoNull()
        {
            var mock = new Mock<IBibliotecaService>();
            mock.Setup(a => a.BibliotecaFindLibroIdyUsuarioId(1,1)).Returns(new Biblioteca());
            mock.Setup(a => a.SaveChanges());
            
            var controller = new BibliotecaController(mock.Object);
            var view = controller.MarcarComoLeyendo(1) as RedirectToRouteResult;
            var valor = controller.TempData;
            Assert.IsNotNull(valor["SuccessMessage"]);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);

        }
        [Test]
        public void MarcarComoTerminadoNull()
        {
            var mock = new Mock<IBibliotecaService>();
            mock.Setup(a => a.BibliotecaFindLibroIdyUsuarioId(1, 1)).Returns(new Biblioteca());
            mock.Setup(a => a.SaveChanges());

            var controller = new BibliotecaController(mock.Object);
            var view = controller.MarcarComoTerminado(1) as RedirectToRouteResult;
            var valor = controller.TempData;
            Assert.IsNotNull(valor["SuccessMessage"]);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);

        }

    }
    [TestFixture]
    public class LoginTestController {
        [Test]
        public void LoginISnotnull() {
            var mock = new Mock<IAuthService>();
        }
    
        [Test]
        public void logoutIsNull()
        {
            Usuario us = null;

            var mock = new Mock<IAuthService>();
            mock.Setup(a => a.UsuarioFind("admin", "admin")).Returns(us);
            var controller = new AuthController(mock.Object);
            var view = (ViewResult)controller.Login("admin", "admin");

            Assert.IsNull(view.Model);
            Assert.IsNotNull(view.ViewBag.validation);
        }



    }

}

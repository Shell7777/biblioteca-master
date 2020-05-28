using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace BibliotecaUPN.Web.Service
{
    public class BibliotecaService : IBibliotecaService
    {

        AppContext app = new AppContext();
        public void BibliotecaAdd(Biblioteca biblioteca) {

            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();
        }
        public List<Biblioteca> bibliotecaWithLibroUsuario (int idusuario){

            return app.Bibliotecas
                    .Include(o => o.Libro.Autor)
                    .Include(o => o.Usuario)
                    .Where(o => o.UsuarioId == idusuario)
                    .ToList();
        }
        public void SaveChanges() {
            app.SaveChanges();
        }
        public Biblioteca BibliotecaFindLibroIdyUsuarioId(int libroId, int userid)
        {
            return app.Bibliotecas
                 .Where(o => o.LibroId == libroId && o.UsuarioId == userid)
                 .FirstOrDefault();
        }
    }
    public interface IBibliotecaService{
        Biblioteca BibliotecaFindLibroIdyUsuarioId(int libroId, int userid);
       void BibliotecaAdd(Biblioteca biblioteca);
        void SaveChanges();
        List<Biblioteca> bibliotecaWithLibroUsuario(int idusuario);
    }
}
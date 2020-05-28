
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using BibliotecaUPN.Web.DB;
using System.Data.Entity;
using BibliotecaUPN.Web.Models;
using System.Linq;

namespace BibliotecaUPN.Web.Service
{
    public class LibroService: IserviceLibro
    {
        AppContext app = new AppContext();
        public List<Libro> LibrosListIncludeAutor() {
            return app.Libros.Include(o => o.Autor).ToList();
        }
        public Libro libroFind(int id) { 
            return app.Libros.Where(o => o.Id == id).FirstOrDefault();
        }
        public void saveChanges() {
            app.SaveChanges();
        }
        public void libroAdd(Libro libro) {
            app.Libros.Add(libro);
            app.SaveChanges();
        }
        public Libro libroDetailsIncludeAutorComentarios(int id ) {
            var model = app.Libros.Include(o => o.Autor)
               .Include(o => o.Comentarios.Select(x => x.Usuario))
               .Where(o => o.Id == id)
               .FirstOrDefault();
            return (model);
        }
      
    }

    public interface IserviceLibro {
        List<Libro> LibrosListIncludeAutor();
        Libro libroDetailsIncludeAutorComentarios(int id);
        Libro libroFind(int id);
        void saveChanges();
    }
}
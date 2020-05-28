using BibliotecaUPN.Web.DB.Maps;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.DB
{
    public class AppContext : DbContext
    {

        public IDbSet<Libro> Libros { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Biblioteca> Bibliotecas { get; set; }
        public IDbSet<Comentario> Comentarios { get; set; }
        public IDbSet<Autor> Autores { get; set; }

        public AppContext()
        {
            Database.SetInitializer<AppContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new LibroMap());
            modelBuilder.Configurations.Add(new BibliotecaMap());
            modelBuilder.Configurations.Add(new ComentarioMap());
            modelBuilder.Configurations.Add(new AutorMap());


        }
    }
}
using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.Service
{
    public class ComentaioService : IComentaioService
    {
        AppContext app = new AppContext();
        public void Add(Comentario comentario) {
            app.Comentarios.Add(comentario);
        }
    }
    public interface IComentaioService {
        void Add(Comentario comentario);
    }
}
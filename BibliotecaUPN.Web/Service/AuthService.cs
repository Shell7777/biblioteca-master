using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.Service
{
    public class AuthService: IAuthService
    {

        AppContext app = new AppContext();
        public Usuario UsuarioFind(string username, string password) { 
              return app.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }
    }
    public interface IAuthService {
        Usuario UsuarioFind(string username, string password);
    }
}
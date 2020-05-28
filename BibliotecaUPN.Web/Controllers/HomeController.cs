using BibliotecaUPN.Web.DB;
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
    public class HomeController : Controller
    {
        IserviceLibro iservice; 
        public HomeController(IserviceLibro iservice)
        {
            this.iservice = iservice;
        }
        public HomeController()
        {
            this.iservice = new LibroService();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = iservice.LibrosListIncludeAutor();
            return View(model);
        }       

    }
}
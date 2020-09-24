using SegundoParcialProg3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SegundoParcialProg3.Controllers
{
    public class ConcesionariaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Concesionaria
        public ActionResult Agregar()
        {
            GestorConcesionaria gestor = new GestorConcesionaria();
            Auto a = new Auto();
            AutosViewModel avm = new AutosViewModel();
            avm.Vehiculo = a;
            avm.listaMarcas = gestor.ObtenerMarcas();
            return View(avm);
        }

        [HttpPost]
        public ActionResult Agregar(AutosViewModel avm)
        {
            GestorConcesionaria gestor = new GestorConcesionaria();

            gestor.AgregarAuto(avm.Vehiculo);

            List<AutoMarca> lista = gestor.ObtenerAutos();
            return View("Listar", "", lista);
        }

        public ActionResult Listar()
        {
            GestorConcesionaria gestor = new GestorConcesionaria();
            List<AutoMarca> lista = gestor.ObtenerAutos();

            return View("Listar", "", lista);
        }

        public ActionResult ListarOfertas()
        {
            GestorConcesionaria gestor = new GestorConcesionaria();
            List<AutoMarca> lista = gestor.ObtenerAutosOfertados();

            return View("ListarOfertas", "", lista);
        }

        public ActionResult AutoUsado()
        {
            GestorConcesionaria gestor = new GestorConcesionaria();
            AutoMarca auto = gestor.ObtenerAutoUsado();

            return View(auto);
        }
    }
}
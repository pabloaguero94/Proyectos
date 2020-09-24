using ABMPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABMPersonas.Controllers
{
    public class PersonasController : Controller
    {
         public ActionResult Agregar()
        {
            /*Persona p = new Persona(0, "Juan", "Perez", 30);
            GestorPersonas gestorPersonas = new GestorPersonas();
            gestorPersonas.AgregarPersona(p);
            */
            GestorPersonas g = new GestorPersonas();

            Persona p = new Persona();
            PersonaViewModel pvm = new PersonaViewModel();
            pvm.persona = p;
            pvm.listaec = g.ObtenerEstadosCiviles();

            return View(pvm);
        }

        [HttpPost]
        public ActionResult Agregar(PersonaViewModel pvm)
        {
            GestorPersonas g = new GestorPersonas();
            g.AgregarPersona(pvm.persona);

            List<PersonaConEstadoCivil> lista = g.ObtenerPersonas();
            return View("Listar", "", lista);
        }

        public ActionResult Eliminar(int id)
        {
            GestorPersonas g = new GestorPersonas();
            g.Eliminar(id);

            List<PersonaConEstadoCivil> lista = g.ObtenerPersonas();
            return View("Listar", "", lista);
        }

        public ActionResult Listar()
        {
            GestorPersonas gestorPersonas = new GestorPersonas();
            List<PersonaConEstadoCivil> lista = gestorPersonas.ObtenerPersonas();
            
            return View("Listar","",lista);
        }

        public ActionResult Editar(int id)
        {
            GestorPersonas g = new GestorPersonas();
            Persona p = g.ObtenerPersona(id);

            //List<EstadoCivil> le = g.ObtenerEstadosCiviles();

            return View(p);
        }

        [HttpPost]
        public ActionResult Editar(Persona p)
        {
            GestorPersonas g = new GestorPersonas();
            g.Modificar(p);

            List<PersonaConEstadoCivil> lista = g.ObtenerPersonas();
            return View("Listar", "", lista);
        }
    }
}
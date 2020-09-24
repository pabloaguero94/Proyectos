using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMPersonas.Models
{
    public class PersonaViewModel
    {
        public Persona persona { get; set;  }
        public List<EstadoCivil> listaec { get; set; }
    }
}
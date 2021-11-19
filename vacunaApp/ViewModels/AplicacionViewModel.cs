using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vacunaApp.Models;

namespace vacunaApp.ViewModels
{
    public class AplicacionViewModel
    {
        public Persona Persona { get; set; }
        public List<Vacunas> Vacunas {get; set;}
        public string VacunaSeleccionada { get; set; }
    }
}
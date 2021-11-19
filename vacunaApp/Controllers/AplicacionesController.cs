using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vacunaApp.App_Start;
using MongoDB.Driver;
using vacunaApp.Services;
using vacunaApp.Models;
using vacunaApp.ViewModels;

namespace vacunaApp.Controllers
{
    public class AplicacionesController : Controller
    {
        public PersonaService personaService;
        public VacunasService vacunasService;
        public AplicacionesController()
        {
            personaService = new PersonaService();
            vacunasService = new VacunasService();

        }

        //funciona como un Editar
        public ActionResult Vacunar(string id)
        {
            var model = new AplicacionViewModel();
            Persona persona = personaService.GetPersona(id);
            List<Vacunas> vacunas = vacunasService.GetVacunas();
            
            model.Persona = persona;
            model.Vacunas = vacunas;

            return View(model);
        }

        [HttpPost]
        public ActionResult Vacunar(AplicacionViewModel model, string id)
        {
            try
            {
                Persona persona = personaService.GetPersona(id);
                Aplicacion aplicacion = new Aplicacion();
                aplicacion.Fecha = DateTime.Now;
                var vacunaID = model.VacunaSeleccionada;

                Vacunas vacuna = vacunasService.GetVacuna(vacunaID);
                vacuna.Stock = vacuna.ActualizarStock();
                aplicacion.Vacuna = vacuna.TipoVacuna;

                List<Aplicacion> aplicaciones = new List<Aplicacion>();
                persona.DosisAplicadas = aplicaciones;
                persona.DosisAplicadas.Add(aplicacion);
 
                personaService.EditarPersona(persona);
                vacunasService.EditarVacunas(vacuna);
                return RedirectToAction("Index", "Persona");
            }
            catch
            {
                return View();
            }
        }
    }
}

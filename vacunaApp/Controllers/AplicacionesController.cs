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
using vacunaApp.Logs;

namespace vacunaApp.Controllers
{
    public class AplicacionesController : Controller
    {
        private PersonaService personaService;
        private VacunasService vacunasService;
        private AplicacionesService aplicacionesService;
        public AplicacionesController()
        {
            personaService = new PersonaService();
            vacunasService = new VacunasService();
            aplicacionesService = new AplicacionesService();
        }

        ILogger logger = FileLogger.Instance;

        public ActionResult Vacunar(string id)
        {
            try
            {
                var model = new AplicacionViewModel();
                Persona persona = personaService.GetPersona(id);
                List<Vacunas> vacunas = vacunasService.GetVacunas();

                model.Persona = persona;
                model.Vacunas = vacunas;

                return View(model);
            }
            catch (Exception e)
            {
                logger.LogException(e);
                ViewBag.Message = "Error al procesar solicitud de aplicación";
                return RedirectToAction("UnexpectedError", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult Vacunar(AplicacionViewModel model, string id)
        {
            try
            {
                AplicarVacuna(model, id);
                return RedirectToAction("Index", "Persona");
            }
            catch(Exception e)
            {
                logger.LogException(e);
                ViewBag.Message = "Ocurrió un error al realizar la petición";
                return RedirectToAction("UnexpectedError", "Error");
            }
        }

        public ActionResult Data()
        {
            try
            {
                List<Aplicacion> aplicaciones = aplicacionesService.GetAplicaciones();
                LoadDashboard(aplicaciones);

                return View(aplicaciones);
            }
            catch (Exception e)
            {
                logger.LogException(e);
                ViewBag.Message = "Ocurrió un error al realizar la petición";
                return RedirectToAction("UnexpectedError", "Error");
            } 
        }

        [HttpPost]
        public ActionResult Data(DateTime hasta, DateTime desde)
        {
            try
            {
                List<Aplicacion> aplicaciones = aplicacionesService.GetAplicaciones();
                LoadDashboard(aplicaciones);
                List<Aplicacion> aplicacionesFiltradas = aplicacionesService.BuscarAplicacionesPorFecha(aplicaciones, desde, hasta);
                return View(aplicacionesFiltradas);
            }
            catch(Exception e)
            {
                logger.LogException(e);
                ViewBag.Message = "Ocurrió un error al realizar la petición";
                return RedirectToAction("UnexpectedError", "Error");
            }  
        }

        #region HELPERS
        private void LoadDashboard(List<Aplicacion> aplicaciones)
        {
            
            List<Aplicacion> Pfizer = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Pfizer");
            int pfizerCounter = Pfizer.Count();
            List<Aplicacion> Sinopharm = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Sinopharm");
            int sinopharmCounter = Sinopharm.Count();
            List<Aplicacion> Sputnik = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Sputnik");
            int sputnikCounter = Sputnik.Count();
            List<Aplicacion> Astra = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Astra Zeneca");
            int astraCounter = Astra.Count();

            ViewBag.PfizerCounter = pfizerCounter;
            ViewBag.SinopharmCounter = sinopharmCounter;
            ViewBag.SputnikCounter = sputnikCounter;
            ViewBag.AstraCounter = astraCounter;
        }

        private void AplicarVacuna(AplicacionViewModel model, string id)
        {
            Persona persona = personaService.GetPersona(id);
            Aplicacion aplicacion = new Aplicacion();
            aplicacion.Fecha = DateTime.Now;
            var vacunaID = model.VacunaSeleccionada;
            Vacunas vacuna = vacunasService.GetVacuna(vacunaID);
            aplicacion.Vacuna = vacuna.TipoVacuna;

            if (persona.DosisAplicadas.Count() < 3)
            {
                vacuna.Stock = vacuna.ActualizarStock();
                persona.DosisAplicadas.Add(aplicacion);
                personaService.EditarPersona(persona);
                vacunasService.EditarVacunas(vacuna);
                aplicacionesService.CrearAplicacion(aplicacion);
            }
        }
        
        #endregion
    }
}

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
        public AplicacionesService aplicacionesService;
        public AplicacionesController()
        {
            personaService = new PersonaService();
            vacunasService = new VacunasService();
            aplicacionesService = new AplicacionesService();
        }

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
            catch (Exception)
            {
                return RedirectToAction("Index", "Persona");
            }
            
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
                aplicacion.Vacuna = vacuna.TipoVacuna;

                if(persona.DosisAplicadas.Count() < 3)
                {
                    vacuna.Stock = vacuna.ActualizarStock();
                    persona.DosisAplicadas.Add(aplicacion);
                    personaService.EditarPersona(persona);
                    vacunasService.EditarVacunas(vacuna);
                    aplicacionesService.CrearAplicacion(aplicacion);
                }
                
                return RedirectToAction("Index", "Persona");
            }
            catch(Exception)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al realizar la petición";
                return View();
            }
        }

        public ActionResult Data()
        {
            try
            {
                List<Aplicacion> aplicaciones = aplicacionesService.GetAplicaciones();
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

                return View(aplicaciones);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al realizar la petición";
                return View();
            } 
        }

        [HttpPost]
        public ActionResult Data(DateTime hasta, DateTime desde)
        {
            try
            {
                List<Aplicacion> aplicaciones = aplicacionesService.GetAplicaciones();
                List<Aplicacion> Pfizer = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Pfizer");
                int pfizerCounter = Pfizer.Count();
                List<Aplicacion> Sinopharm = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Sinopharm");
                int sinopharmCounter = Sinopharm.Count();
                List<Aplicacion> Sputnik = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Sputnik");
                int sputnikCounter = Sputnik.Count();
                List<Aplicacion> Astra = aplicacionesService.BuscarAplicacionesPorTipo(aplicaciones, "Astra Zeneca");
                int astraCounter = Astra.Count();

                List<Aplicacion> aplicacionesFiltradas = aplicacionesService.BuscarAplicacionesPorFecha(aplicaciones, desde, hasta);

                ViewBag.PfizerCounter = pfizerCounter;
                ViewBag.SinopharmCounter = sinopharmCounter;
                ViewBag.SputnikCounter = sputnikCounter;
                ViewBag.AstraCounter = astraCounter;

                return View(aplicacionesFiltradas);
            }
            catch(Exception)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al realizar la petición";
                return View();
            }   
        }
    }
}

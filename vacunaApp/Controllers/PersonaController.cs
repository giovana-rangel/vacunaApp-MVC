using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vacunaApp.App_Start;
using MongoDB.Driver;
using vacunaApp.Services;
using vacunaApp.Models;

namespace vacunaApp.Controllers
{
    public class PersonaController : Controller
    {
        public PersonaService personaService;
        public PersonaController()
        {
            personaService = new PersonaService();
        }
        public ActionResult Index()
        {
            var personas = personaService.GetPersonas();
            return View(personas);
        }

        public ActionResult Create()
        {
            var list = new List<string>() { "Documento Nacional de Identidad", "Libreta Cívica", "Libreta de Enrolamiento" };
            ViewBag.list = list;

            var persona = new Persona();
            persona.contacto = new Contacto();
            persona.Direccion = new Direccion();
            return View(persona);
        }

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            try
            {
                personaService.CrearPersona(persona);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                throw new Exception ($"Error: {e.Message}");
            }
        }

  
        public ActionResult Details(string id)
        {
            var persona = personaService.GetPersona(id);
            return View(persona);
        }
    }
}
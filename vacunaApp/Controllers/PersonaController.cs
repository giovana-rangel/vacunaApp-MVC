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
            try
            {
                var personas = personaService.GetPersonas();
                return View(personas);
            }
            catch (Exception)
            {
                return ViewBag.Message = "Ocurrió un error al cargar Personas";
            }   
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
            var list = new List<string>() { "Documento Nacional de Identidad", "Libreta Cívica", "Libreta de Enrolamiento" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                try
                {
                    var personas = personaService.GetPersonas();
                    var filter = personas.Find(p => p.NumeroDocumento == persona.NumeroDocumento);
                    if (filter == null)
                    {
                        personaService.CrearPersona(persona);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = $"Ya existe una persona registrada con el número de documento {persona.NumeroDocumento}";
                        return View(persona);
                    }
                    
                }
                catch (Exception)
                {
                    return ViewBag.Message = "Ocurrió un error al crear Persona";
                }
            }

            return View(persona);
        }

        public ActionResult Details(string id)
        {
            try
            {
                var persona = personaService.GetPersona(id);
                return View(persona);
            }
            catch (Exception)
            {
                return ViewBag.Message = "Ocurrió un error al cargar Persona";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using vacunaApp.Services;
using vacunaApp.Models;
using vacunaApp.Logs;


namespace vacunaApp.Controllers
{
    [HandleError]
    public class PersonaController : Controller
    {
        private readonly PersonaService personaService;
        public PersonaController()
        {
            personaService = new PersonaService();
        }

        readonly ILogger logger = FileLogger.Instance;

        public ActionResult Index()
        {  
            try
            {  
                var personas = personaService.GetPersonas();
                return View(personas);
            }
            catch (Exception e)
            {
                logger.LogException(e);
                ViewBag.Message("Ocurrió un error al cargar Personas");
                return RedirectToAction("UnexpectedError", "Error");
            }   
        }

        public ActionResult Create()
        {
            LoadDocumentDropdown();
            var persona = new Persona
            {
                contacto = new Contacto(),
                Direccion = new Direccion()
            };
            return View(persona);
        }

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            LoadDocumentDropdown();
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
                catch (Exception e)
                {
                    logger.LogException(e);
                    ViewBag.Message = "Ocurrió un error al crear Personas";
                    return RedirectToAction("UnexpectedError", "Error");
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
            catch (Exception e)
            {
                logger.LogException(e);
                ViewBag.Message = "Ocurrió un error al cargar Persona";
                return RedirectToAction("UnexpectedError", "Error");
            }
        }

        #region HELPERS
        private void LoadDocumentDropdown()
        {
            var list = new List<string>() { "Documento Nacional de Identidad", "Libreta Cívica", "Libreta de Enrolamiento" };
            ViewBag.list = list;
        }

        #endregion
    }
}
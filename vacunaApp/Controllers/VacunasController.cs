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
    public class VacunasController : Controller
    {
        public VacunasService vacunasService;

        public VacunasController()
        {
            vacunasService = new VacunasService();
        }

        public ActionResult Index()
        {
            var vacunas = vacunasService.GetVacunas();
            return View(vacunas);
        }

        public ActionResult Create()
        {
            var list = new List<string>() { "Sputnik", "Sinopharm", "Pfizer", "Astra Zeneca" };
            ViewBag.list = list;
            var vacunas = new Vacunas();
            return View(vacunas);
        }

        [HttpPost]
        public ActionResult Create(Vacunas vacunas)
        {
            try
            {
                vacunasService.CrearVacunas(vacunas);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}

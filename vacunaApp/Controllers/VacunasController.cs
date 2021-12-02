using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vacunaApp.App_Start;
using MongoDB.Driver;
using vacunaApp.Services;
using vacunaApp.Models;
using vacunaApp.Logs;

namespace vacunaApp.Controllers
{
    public class VacunasController : Controller
    {
        private VacunasService vacunasService;

        public VacunasController()
        {
            vacunasService = new VacunasService();
        }

        ILogger logger = FileLogger.Instance;
        public ActionResult Index()
        {
            try
            {
                var vacunas = vacunasService.GetVacunas();
                return View(vacunas);
            }
            catch (Exception e)
            {
                logger.LogException(e);
                ViewBag.Message = "Ocurrió un error al cargar las vacunas";
                return RedirectToAction("UnexpectedError", "Error");
            }
        }

        public ActionResult Create()
        {
            LoadVacunasDropdown();
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
                logger.LogException(e);
                ViewBag.Message = "Ocurrió un error al cargar las vacunas";
                return RedirectToAction("UnexpectedError", "Error");
            }
        }

        #region HELPERS
        private void LoadVacunasDropdown()
        {
            var list = new List<string>() { "Sputnik", "Sinopharm", "Pfizer", "Astra Zeneca" };
            ViewBag.list = list;
        }
        #endregion
    }
}

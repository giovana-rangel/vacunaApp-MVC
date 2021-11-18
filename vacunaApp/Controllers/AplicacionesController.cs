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
    public class AplicacionesController : Controller
    {
        public AplicacionesService aplicacionesService;
        public AplicacionesController()
        {
            aplicacionesService = new AplicacionesService();
        }
        public ActionResult Index()
        {
            var aplicaciones = aplicacionesService.GetAplicaciones();
            return View(aplicaciones);
        }

        /*
        // GET: Aplicaciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aplicaciones/Create
        public ActionResult Create()
        {
            return View();
        }
        */

        /*
        // POST: Aplicaciones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Aplicaciones Aplicaciones = new Aplicaciones();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aplicaciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aplicaciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aplicaciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aplicaciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}

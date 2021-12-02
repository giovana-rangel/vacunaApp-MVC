using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vacunaApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error404
        public ActionResult PageNotFound()
        {
            return View();
        }
        
        // GET: ErrorGeneral
        public ActionResult UnexpectedError()
        {
            return View();
        }

    }
}

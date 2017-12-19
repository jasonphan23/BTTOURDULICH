using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;

namespace TOURDULICH_WEB.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        Database<Tour> dbTour = new Database<Tour>();
        public JsonResult laydanhsachtour()
        {
            var list = dbTour.GetList().Select(x => new { label = x.Ten, value = x.MaTour, }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}

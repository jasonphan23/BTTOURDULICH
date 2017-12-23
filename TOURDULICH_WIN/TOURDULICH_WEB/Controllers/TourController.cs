using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using TOURDULICH_WIN.BIZ;
namespace TOURDULICH_WEB.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        TOUR_BIZ dbTour = new TOUR_BIZ();
        public JsonResult laydanhsachtour()
        {
            var list = dbTour.GetListDSWEB();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}

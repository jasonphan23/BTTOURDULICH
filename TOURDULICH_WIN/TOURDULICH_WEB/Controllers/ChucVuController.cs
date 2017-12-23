using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
using TOURDULICH_WIN.BIZ;
namespace TOURDULICH_WEB.Controllers
{
    public class ChucVuController : Controller
    {
        //
        // GET: /ChucVu/
        CHUCVU_BIZ dbcv = new CHUCVU_BIZ();
        
        public List<ChucVu> GetList()
        {
            return dbcv.GetList();
        }

    }
}

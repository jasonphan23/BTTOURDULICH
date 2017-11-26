﻿using DATABASE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using System.Collections;


namespace TOURDULICH_WIN.BAL
{
    class TOUR_BAL
    {
        
         Database<Tour> db;
         public TOUR_BAL()
        {
            db = new Database<Tour>();
        }
        public IEnumerable GetList()
        {

            var list = db.GetList().Where(x=>x.TrangThai==true).Select(x => new {x.Ten,LoaiHinhDuLich = x.LoaiHinhDL1.Ten,x.DacDiem,x.DiemBatDau,x.DiemKetThuc}).ToList();
            return list;
        }
    }
}

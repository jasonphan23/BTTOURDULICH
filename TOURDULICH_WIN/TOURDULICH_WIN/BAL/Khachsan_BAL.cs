using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
namespace TOURDULICH_WIN.BAL
{
    class Khachsan_BAL
    {
         Database<KhachSan> repo;
        public Khachsan_BAL()
        {
            repo = new Database<KhachSan>();
        }
        public List<KhachSan> Lst_Khachsan()
        {
            return repo.GetList();
        }
    }
}

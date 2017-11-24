using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
namespace TOURDULICH_WIN.BAL
{
    class QuanAn_BAL
    {
          Database<QuanAn> repo;
        public QuanAn_BAL()
        {
            repo = new Database<QuanAn>();
        }
        public List<QuanAn> Lst_QuanAn()
        {
            return repo.GetList();
        }
    }
}

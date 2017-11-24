using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
namespace TOURDULICH_WIN.BAL
{
    public class DiaDiem_BAL
    {
        Database<DiaDiem> repo;
        public DiaDiem_BAL()
        {
            repo = new Database<DiaDiem>();
        }
        public List<DiaDiem> Lst_Diadiem()
        {
            return repo.GetList();
        }

    }
}

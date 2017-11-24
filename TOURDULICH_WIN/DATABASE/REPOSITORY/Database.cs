using DATABASE.MODELS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATABASE.REPOSITORY
{
    public class Database<T> where T : class
    {
        public TourDLEntities db = new TourDLEntities();
        public static string error_message = "";
        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }
        public bool Insert(T dto)
        {
            bool ok = false;
            try
            {
                db.Entry(dto).State = EntityState.Added;
                db.SaveChanges();
                ok = true;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return ok;
        }
        public bool Delete(T dto)
        {
            bool ok = false;
            {
                try
                {
                    db.Entry(dto).State = EntityState.Deleted;
                    db.SaveChanges();
                    ok = true;
                }
                catch (Exception ex)
                {
                    error_message = ex.Message;
                }
            }
            return ok;
        }
        public bool Update(T dto)
        {
            bool ok = false;
            {
                try
                {
                    db.Entry(dto).State = EntityState.Modified;
                    db.SaveChanges();
                    ok = true;
                }
                catch (Exception ex)
                {
                    error_message = ex.Message;
                }
            }
            return ok;
        }

        public List<T> Search(Expression<Func<T, bool>> where)
        {

            return db.Set<T>().Where(where).ToList();
        }
        //lay duy nhat
        public T GetSingle(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
        public bool Exists(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Any(where);
        }

    }

 
}

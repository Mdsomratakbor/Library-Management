using LibraryManagement.Data;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Abstractclass
{
    public abstract class LibraryMangementServices<T> where T: class 
    {

        public virtual bool UpdateData(T model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return _LMContext.SaveChanges() > 0;
            }
        }
        public virtual bool SaveData(T model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Set<T>().Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }
        public virtual bool DeleteData(int id)
        {
            using (var _LMContext = new LMContext())
            {
                var designation = _LMContext.Set<T>().Find(id);
                _LMContext.Entry(designation).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Set<T>().Remove(designation);
                return _LMContext.SaveChanges() > 0;
            }
        }
        public virtual int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Set<T>().Count();
            }
        }
        public virtual T GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Set<T>().Find(id);
            }
        }
        public List<T> GetAllData()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Set<T>().ToList();
            }
        }
    }
}

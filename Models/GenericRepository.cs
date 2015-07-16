using DemoCrudGenericRepository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoCrudGenericRepository.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        private DataContext _db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            _db = new DataContext();
            table = _db.Set<T>();
        }

        //public GenericRepository(DataContext db)
        //{
        //    _db = db;
        //    table = db.Set<T>();
        //}

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object Id)
        {
            return table.Find(Id);
        }

        public void Insert(T model)
        {
            table.Add(model);
        }

        public void Update(T model)
        {
            table.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            
        }

        public void Delete(object Id)
        {
            var model = table.Find(Id);
            table.Remove(model);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCrudGenericRepository.Models
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Insert(T model);
        void Update(T model);
        void Delete(object Id);
        void Save();
    }
}
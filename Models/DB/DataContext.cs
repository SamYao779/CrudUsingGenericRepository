using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoCrudGenericRepository.Models.DB
{
    public class DataContext : DbContext
    {
        public DataContext() : base("RespositoryData") { }

        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
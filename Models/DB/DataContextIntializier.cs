using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoCrudGenericRepository.Models.DB
{
    public class DataContextIntializier : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            context.Contacts.Add(new Contact { FirstName = "Lê Văn", LastName = "Tèo", Address = "188 CMT8", Email = "teo@gmail.com" });

            context.SaveChanges();
        }
    }
}
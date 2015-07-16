using DemoCrudGenericRepository.Models;
using DemoCrudGenericRepository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoCrudGenericRepository.Controllers
{
    public class TestCrudRepositoryController : Controller
    {
        IGenericRepository<Contact> db = new GenericRepository<Contact>();
        //
        // GET: /TestCrudRepository/
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Contact model)
        {
            try
            {
                db.Insert(model);
                db.Save();
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        public ActionResult Edit(int Id)
        {
            var model = db.GetById(Id);
            return PartialView("_Edit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(Contact model)
        {
            try
            {
                db.Update(model);
                db.Save();
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        public ActionResult ConfirmDelete(int Id)
        {
            var model = db.GetById(Id);
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            db.Delete(Id);
            db.Save();
            return RedirectToAction("Index");
        }
    }
}
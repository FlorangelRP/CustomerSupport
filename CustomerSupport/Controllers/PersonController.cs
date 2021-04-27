using CustomerSupport.BDContext;
using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CustomerSupport.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult ListPerson()
        {
            return View();
        }

        public ActionResult GetListPerson()
        {
            List<MPerson> ListPerson = new List<MPerson>();            
            MMEnterprisesEntities db = new MMEnterprisesEntities();

            ListPerson = (from result in db.GNListPerson(null).ToList()
                        select new MPerson
                        {
                            IdPerson= result.IdPerson,
                            IdPersonType= result.IdPersonType,
                            PersonType= result.PersonType,
                            IdIdentificationType= result.IdIdentificationType,
                            IdentificationType= result.IdentificationType,
                            NumIdentification= result.NumIdentification,
                            Name= result.Name,
                            LastName= result.LastName,
                            Birthday= result.Birthday,
                            Address= result.Address,
                            Email= result.Email,
                            IdContactType= result.IdContactType,
                            ContactType= result.ContactType,
                            IdPosition= result.IdPosition,
                            Position= result.Position,
                            ClientPermission= result.ClientPermission,
                            Status= result.Status
                        }).ToList();

            return Json(ListPerson, JsonRequestBehavior.AllowGet); 

        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

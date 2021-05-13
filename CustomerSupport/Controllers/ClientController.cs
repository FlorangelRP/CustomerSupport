using CustomerSupport.BDContext;
using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CustomerSupport.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult ListClient()
        {
            return View();
        }

        public ActionResult GetListClient()
        {
            List<MPerson> ListPerson = new List<MPerson>();            
            MMEnterprisesEntities db = new MMEnterprisesEntities();

            ListPerson = (from result in db.GNListPerson(null,1).ToList()
                        select new MPerson
                        {
                            IdPerson = result.IdPerson,
                            IdPersonType = result.IdPersonType,
                            PersonType = result.PersonType,
                            IdIdentificationType = result.IdIdentificationType,
                            IdentificationType = result.IdentificationType,
                            NumIdentification = result.NumIdentification,
                            Name = result.Name,
                            LastName = result.LastName,
                            Birthday = result.Birthday,
                            Address = result.Address,
                            Email = result.Email,
                            IdContactType = result.IdContactType,
                            ContactType = result.ContactType,
                            IdPosition = result.IdPosition,
                            Position = result.Position,
                            ClientPermission = result.ClientPermission,
                            Status = result.Status,
                            StatusDesc = result.Status==true ? "Activo" : "Inactivo"
                        }).ToList();

            return Json(ListPerson, JsonRequestBehavior.AllowGet); 

        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Client/Create
        public ActionResult AddClient()
        {
            return View();
        }

        // POST: Client/Create
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

        // GET: Client/Edit/5
        public ActionResult EditClient(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
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

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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

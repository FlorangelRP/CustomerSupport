using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerSupport.BDContext;
using CustomerSupport.Models;

namespace CustomerSupport.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ListUser()
        {
            return View();
        }

        public ActionResult GetListUser()
        {            
            List<MUser> ListUser = new List<MUser>();
            MMEnterprisesEntities db = new MMEnterprisesEntities();

            ListUser = (from result in db.GNListUser(null).ToList()
                        select new MUser
                        {
                            IdUser = result.IdUser,
                            IdPerson = result.IdPerson,
                            Login = result.Login,
                            Status = result.Status
                        }).ToList();

            return Json(ListUser, JsonRequestBehavior.AllowGet); 
            
        }

        public ActionResult Login()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5int id
        public ActionResult EditUser()
        {
            Models.MUser mlUser = new Models.MUser();
            using (MMEnterprisesEntities db = new MMEnterprisesEntities())
            {
                mlUser = (from d in db.Users
                        select new Models.MUser
                        {
                            IdUser = d.IdUser,
                            IdPerson = d.IdPerson,
                            //IdPosition = d.IdPosition,
                            //Position ="",
                            Login = d.Login,
                            Status = d.Status
                        }).First();
                mlUser.PersonEmployee = new MPerson();
                mlUser.PersonEmployee.IdIdentificationType = 1;
                mlUser.PersonEmployee.NumIdentification ="14270679";
                mlUser.PersonEmployee.LastName = "Lucena";
                mlUser.PersonEmployee.Name = "Lucena";
                
            }

            return View(mlUser);
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

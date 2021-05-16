using CustomerSupport.BDContext;
using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace CustomerSupport.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult ListEmployee()
        {
            return View();
        }

        public ActionResult GetListEmployee()
        {
            List<MPerson> ListPerson = new List<MPerson>();            
            MMEnterprisesEntities db = new MMEnterprisesEntities();

            ListPerson = (from result in db.GNListPerson(null,2).ToList()
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
                            Status= result.Status,
                            StatusDesc = result.Status == true ? "Activo" : "Inactivo"
                        }).ToList();

            return Json(ListPerson, JsonRequestBehavior.AllowGet); 

        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Employee/Create
        public ActionResult AddEmployee()
        {
            var model = new MPerson();
            return View(model);
        }

        [HttpPost]
        public string AddEmployee(MPerson objPerson)
        {
            return "HOLA SOY UNA PERSONA";
        }


        //// POST: Employee/Create
        //[HttpPost]
        //public string Create(MPerson objPersonEmployee, FormCollection objForm)
        //{   //, string[][] objContact  , List<MPersonContac> TPersonContact

        //    var TPersonContact = new StringBuilder();
        //    try
        //    {
        //        if (objPersonEmployee!=null)
        //        {
        //           var result= objForm.AllKeys.Where(k => k.Contains("listPersonContact")).ToArray<string>();
        //            objPersonEmployee.IdPersonType = 2; //set por defecto tipo "Empleado"

        //            foreach (var key in objForm.AllKeys.Where(k => k.Contains("listPersonContact")).ToArray<string>()) 
        //            {
        //                var valor = objForm[key];
        //            }

        //            if (TPersonContact != null)
        //            {
        //                //foreach (var item in TPersonContact)
        //                //{
        //                //    objPersonEmployee.listPersonContact.Add(new MPersonContac
        //                //    {
        //                //        IdContact = 0,
        //                //        IdPerson = 0,
        //                //        IdPhoneNumberType = int.Parse(item[0]),
        //                //        IdIsoCountry = item[2],
        //                //        PhoneNumber = item[4],
        //                //        Status = true
        //                //    });
        //                //}
        //            }
        //        }

        //        //return RedirectToAction("AddEmployee");
        //        return TPersonContact.ToString(); //Json(true);
        //    }
        //    catch
        //    {
        //        return TPersonContact.ToString(); //Json(false);
        //    }
        //}

        // GET: Employee/Edit/5
        public ActionResult EditEmployee(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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

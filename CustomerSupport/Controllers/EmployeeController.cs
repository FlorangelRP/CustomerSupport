using CustomerSupport.BDContext;
using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
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
        public ActionResult AddEmployee(MPerson objPersonEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MMEnterprisesEntities db = new MMEnterprisesEntities();
                    int IdContact;
                    int IdPerson;
                    ObjectParameter paramOutIdPerson = new ObjectParameter("IdPerson", typeof(int));
                    //DateTime birthdayformat = (DateTime)Convert.ToDateTime(objPersonEmployee.Birthday).GetDateTimeFormats()[46];

                    IdPerson = db.GNTranPerson("I", paramOutIdPerson, 2, objPersonEmployee.IdIdentificationType, objPersonEmployee.NumIdentification,
                        objPersonEmployee.Name, objPersonEmployee.LastName, objPersonEmployee.Birthday,
                        objPersonEmployee.Address, objPersonEmployee.Email, objPersonEmployee.IdContactType,
                        objPersonEmployee.IdPosition, objPersonEmployee.ClientPermission, true);

                    IdPerson = Int32.Parse(paramOutIdPerson.Value.ToString());
                    if (IdPerson != 0)
                    {
                        ObjectParameter paramOutIdContact = new ObjectParameter("IdContact", typeof(int));
                        foreach (var item in objPersonEmployee.listPersonContact)
                        {
                            IdContact = db.GNTranPersonContact("I", paramOutIdContact, IdPerson, item.IdPhoneNumberType, item.IdIsoCountry, item.PhoneNumber, true);
                            IdContact = Int32.Parse(paramOutIdContact.Value.ToString());
                        }
                    }
                    return View("ListEmployee");
                }
                else 
                {
                    return View(objPersonEmployee);
                }
                
            }
            catch (SqlException ex)
            {
                //throw;
                string msg= "Error al grabar datos del empleado: " + ex.Message;
                ModelState.AddModelError("ErrorSave", msg);
                return View(objPersonEmployee);
            }

        }

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

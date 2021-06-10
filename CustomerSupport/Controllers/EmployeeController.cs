using CustomerSupport.BDContext;
using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        public ActionResult GetListEmployee()
        {
            List<MPerson> ListPerson = new List<MPerson>();
            ListPerson = PersonController.fnListPerson(null, 2); //2-empleado

            return Json(ListPerson, JsonRequestBehavior.AllowGet); 

        }

        // GET: Employee/DetailEmployee/5
        public ActionResult DetailEmployee(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            MPerson objPersonEmployee = new MPerson();
            objPersonEmployee = PersonController.fnListPerson(id, 2).First(); //2-empleado
            return View(objPersonEmployee);
        }

        // GET: Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            MPerson objPersonEmployee = new MPerson();
            objPersonEmployee.Birthday = DateTime.Now;
            objPersonEmployee.listPersonContact = new List<MPersonContact>();

            if (TempData["Success"] != null) {
                ViewBag.SuccessSave = TempData["Success"];
            }

            return View(objPersonEmployee);
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(MPerson objPersonEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //valores por defecto
                    objPersonEmployee.Status = true; //activo
                    objPersonEmployee.IdPersonType = 2; //tipo empleado

                    string mensaje = "";
                    int resultDb = PersonController.fnGNTranPerson(objPersonEmployee, "I", ref mensaje);

                    if (resultDb != 0)
                    {
                        TempData["Success"] = mensaje;
                        return RedirectToAction("AddEmployee");
                    }
                    else
                    {
                        ViewBag.ErrorSave = mensaje;
                        return View(objPersonEmployee);
                    }
                }
                else 
                {
                    return View(objPersonEmployee);
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorSave = "Error al grabar datos del empleado: " + ex.Message;
                return View(objPersonEmployee);
            }

        }

        // GET: Employee/EditEmployee/5
        public ActionResult EditEmployee(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            MPerson objPersonEmployee = new MPerson();
            objPersonEmployee = PersonController.fnListPerson(id, 2).First(); //2-empleado

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessSave = TempData["Success"];
            }

            return View(objPersonEmployee);
        }

        // POST: Employee/EditEmployee/
        [HttpPost]
        public ActionResult EditEmployee(MPerson objPersonEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //valores por defecto
                    objPersonEmployee.IdPersonType = 2; //tipo empleado

                    string mensaje = "";
                    int resultDb = PersonController.fnGNTranPerson(objPersonEmployee, "U", ref mensaje);

                    if (resultDb != 0)
                    {
                        TempData["Success"] = mensaje;
                        return RedirectToAction("EditEmployee", new { id = objPersonEmployee.IdPerson });
                    }
                    else
                    {
                        ViewBag.ErrorSave = mensaje;
                        return View(objPersonEmployee);
                    }
                }
                else
                {
                    return View(objPersonEmployee);
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorSave = "Error al grabar datos del empleado: " + ex.Message;
                return View(objPersonEmployee);
            }
        }


    }
}

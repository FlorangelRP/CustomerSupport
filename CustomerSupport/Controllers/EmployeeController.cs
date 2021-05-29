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
            var model = new MPerson();
            model.Birthday = DateTime.Now;
            return View(model);
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
            model.Birthday = DateTime.Now;
            //model.listPersonContact = new List<MPersonContact>();
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
                    int SqlResult;
                    //ObjectParameter paramOutIdPerson = new ObjectParameter("IdPerson", typeof(int));
                    //DateTime birthdayformat = (DateTime)Convert.ToDateTime(objPersonEmployee.Birthday).GetDateTimeFormats()[46];
                    
                    SqlParameter paramOutIdPerson = new SqlParameter("@IdPerson", System.Data.SqlDbType.Int);
                    paramOutIdPerson.Direction = System.Data.ParameterDirection.Output;

                    SqlResult = db.Database.ExecuteSqlCommand("GNTranPerson @TransactionType, @IdPerson OUT, @IdPersonType "+
                                                          ", @IdIdentificationType, @strNumIdentification, @strName, @strLastName, @dttBirthday " +
                                                          ", @strAddress, @strEmail, @IdContactType, @IdPosition, @btClientPermission, @btStatus ",
                           new SqlParameter[]{
                                new SqlParameter("@TransactionType", "I"),
                                paramOutIdPerson,
                                new SqlParameter("@IdPersonType", 2),
                                new SqlParameter("@IdIdentificationType", objPersonEmployee.IdIdentificationType),
                                new SqlParameter("@strNumIdentification", objPersonEmployee.NumIdentification),
                                new SqlParameter("@strName", objPersonEmployee.Name),
                                new SqlParameter("@strLastName", objPersonEmployee.LastName),
                                new SqlParameter("@dttBirthday", objPersonEmployee.Birthday),
                                new SqlParameter("@strAddress", objPersonEmployee.Address),
                                new SqlParameter("@strEmail", objPersonEmployee.Email),
                                new SqlParameter("@IdContactType", DBNull.Value),
                                new SqlParameter("@IdPosition", objPersonEmployee.IdPosition),
                                new SqlParameter("@btClientPermission", objPersonEmployee.ClientPermission),
                                new SqlParameter("@btStatus", true)
                            }
                        );

                    IdPerson = Int32.Parse(paramOutIdPerson.Value.ToString());
                    if (IdPerson != 0)
                    {
                        //ObjectParameter paramOutIdContact = new ObjectParameter("IdContact", typeof(int));
                        SqlParameter paramOutIdContact = new SqlParameter("@IdContact", System.Data.SqlDbType.Int);
                        paramOutIdContact.Direction = System.Data.ParameterDirection.Output;

                        foreach (var item in objPersonEmployee.listPersonContact)
                        {
                            
                            SqlResult = db.Database.ExecuteSqlCommand("GNTranPersonContact @TransactionType, @IdContact OUT, @IdPerson " +
                                                                      ", @IdPhoneNumberType, @strIdIsoCountry, @strPhoneNumber, @btStatus ",
                               new SqlParameter[]{
                                    new SqlParameter("@TransactionType", "I"),
                                    paramOutIdContact,
                                    new SqlParameter("@IdPerson", IdPerson),
                                    new SqlParameter("@IdPhoneNumberType", item.IdPhoneNumberType),
                                    new SqlParameter("@strIdIsoCountry", item.IdIsoCountry),
                                    new SqlParameter("@strPhoneNumber", item.PhoneNumber),
                                    new SqlParameter("@btStatus", true)
                                }
                            );
                            IdContact = Int32.Parse(paramOutIdContact.Value.ToString());
                        }
                                                
                        ViewBag.SuccessSave = "Datos grabados exitosamente, Código de empleado generado: (" + IdPerson + ").";
                        //FALTA QUE LIMPIE LOS CAMPOS Y SOLO MUESTRE EL MENSAJE DE ViewBag.SuccessSave
                        return View();
                    }
                    else
                    {
                        return View(objPersonEmployee);
                    }

                }
                else 
                {
                    return View(objPersonEmployee);
                }
                
            }
            catch (SqlException ex)
            {
                //throw;
                //string msg= "Error al grabar datos del empleado: " + ex.Message;
                //ModelState.AddModelError("ErrorSave", msg);
                ViewBag.ErrorSave = "Error al grabar datos del empleado: " + ex.Message;
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

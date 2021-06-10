using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            { 
                return View();
            }
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
                            Status = result.Status,
                            StatusDesc = result.Status == true ? "Activo" : "Inactivo",
                            PersonEmployee = (MPerson)(from result2 in db.GNListPerson(result.IdPerson, null).ToList()
                                            select new MPerson
                                            {
                                                IdPerson = result2.IdPerson,
                                                IdPersonType = result2.IdPersonType,
                                                PersonType = result2.PersonType,
                                                IdIdentificationType = result2.IdIdentificationType,
                                                IdentificationType = result2.IdentificationType,
                                                NumIdentification = result2.NumIdentification,
                                                Name = result2.Name,
                                                LastName = result2.LastName,
                                                Birthday = result2.Birthday,
                                                Address = result2.Address,
                                                Email = result2.Email,
                                                IdContactType = result2.IdContactType,
                                                ContactType = result2.ContactType,
                                                IdPosition = result2.IdPosition,
                                                Position = result2.Position,
                                                ClientPermission = result2.ClientPermission,
                                                Status = result2.Status
                                            }).ToList().First()
                        }).ToList();

            return Json(ListUser, JsonRequestBehavior.AllowGet); 
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(MUser objUser)
        {
            Session.Timeout = 30;
            try
            {
                objUser.IdPerson = 1;
                
               //if (ModelState.IsValid)
               // { 
                    MMEnterprisesEntities db = new MMEnterprisesEntities();
                    MUser OUser = new MUser();

                    int SqlResult;

                    SqlParameter paramOutIdUsuario = new SqlParameter();
                    paramOutIdUsuario.ParameterName = "@IdUser";
                    paramOutIdUsuario.SqlDbType = System.Data.SqlDbType.Int;
                    paramOutIdUsuario.Direction = System.Data.ParameterDirection.Output;
                    paramOutIdUsuario.Value = objUser.IdUser;

                    SqlResult = db.Database.ExecuteSqlCommand("GNAuthenticationUser @strLogin, @strPassword,@IdUser OUT ",
                           new SqlParameter[]{
                                    new SqlParameter("@strLogin",objUser.Login),
                                    new SqlParameter("@strPassword", OUser.Encriptar(objUser.Password)),
                                    paramOutIdUsuario
                            }
                        );

                    if(SqlResult!=0) 
                    {

                     int IdUser = Int32.Parse(paramOutIdUsuario.Value.ToString());
                        if (IdUser != 0)
                        {

                            MUser ObjUser = new MUser();

                            ObjUser = (from result in db.GNListUser(Convert.ToInt32(IdUser)).ToList()
                                       select new MUser
                                       {
                                           IdUser = result.IdUser,
                                           IdPerson = result.IdPerson,
                                           Login = result.Login,
                                           Status = result.Status,
                                           StatusDesc = result.Status == true ? "Activo" : "Inactivo",
                                           PersonEmployee = (MPerson)(from result2 in db.GNListPerson(result.IdPerson, null).ToList()
                                                                      select new MPerson
                                                                      {
                                                                          IdPerson = result2.IdPerson,
                                                                          IdPersonType = result2.IdPersonType,
                                                                          PersonType = result2.PersonType,
                                                                          IdIdentificationType = result2.IdIdentificationType,
                                                                          IdentificationType = result2.IdentificationType,
                                                                          NumIdentification = result2.NumIdentification,
                                                                          Name = result2.Name,
                                                                          LastName = result2.LastName,
                                                                          Birthday = result2.Birthday,
                                                                          Address = result2.Address,
                                                                          Email = result2.Email,
                                                                          IdContactType = result2.IdContactType,
                                                                          ContactType = result2.ContactType,
                                                                          IdPosition = result2.IdPosition,
                                                                          Position = result2.Position,
                                                                          ClientPermission = result2.ClientPermission,
                                                                          Status = result2.Status
                                                                      }).ToList().First(),
                                           UserAcces = (from result3 in db.GNListUserAcces(result.IdUser, null).ToList()
                                                        select new MUserAcces
                                                        {
                                                            IdOption = result3.IdOption,
                                                            OptionName = result3.OptionName,
                                                            Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                                            Create = result3.Create == null ? false : (bool)result3.Create,
                                                            Search = result3.Search == null ? false : (bool)result3.Search,
                                                            Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                                            Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                                            IdAssociated = result3.IdAssociated,
                                                            Action = result3.Action,
                                                            Controller = result3.Controller,
                                                        }).ToList()
                                       }).First();

                                ObjUser.UserAccesPadre = (from result3 in db.GNListUserAcces(null, null).ToList()
                                                      select new MUserAcces
                                                      {
                                                          IdOption = result3.IdOption,
                                                          OptionName = result3.OptionName,
                                                          Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                                          Create = result3.Create == null ? false : (bool)result3.Create,
                                                          Search = result3.Search == null ? false : (bool)result3.Search,
                                                          Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                                          Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                                          IdAssociated = result3.IdAssociated,
                                                          Action = result3.Action,
                                                          Controller = result3.Controller,
                                                      }).ToList();

                            Session["Usuario"] = ObjUser;

                            return RedirectToAction("Index", "Home");

                        }
                        else
                        {
                            ViewBag.ErrorSave = "Error al Autenticar";
                            return View(objUser);
                        }

                    }
                    else
                    {
                        ViewBag.ErrorSave = "Error al Autenticar";
                        return View(objUser);
                    }
               // }
               //else
               // {
               //     return View(objUser);
               // }
            }
            catch (Exception e)
            {
                ViewBag.ErrorSave = e.Message;
                return View(objUser);
            }

        }

        public ActionResult Details(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DetailUser(string id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                MUser ObjUser = new MUser();
                MMEnterprisesEntities db = new MMEnterprisesEntities();

                ObjUser = (from result in db.GNListUser(Convert.ToInt32(id)).ToList()
                           select new MUser
                           {
                               IdUser = result.IdUser,
                               IdPerson = result.IdPerson,
                               Login = result.Login,
                               Status = result.Status,
                               StatusDesc = result.Status == true ? "Activo" : "Inactivo",
                               PersonEmployee = (MPerson)(from result2 in db.GNListPerson(result.IdPerson, null).ToList()
                                                          select new MPerson
                                                          {
                                                              IdPerson = result2.IdPerson,
                                                              IdPersonType = result2.IdPersonType,
                                                              PersonType = result2.PersonType,
                                                              IdIdentificationType = result2.IdIdentificationType,
                                                              IdentificationType = result2.IdentificationType,
                                                              NumIdentification = result2.NumIdentification,
                                                              Name = result2.Name,
                                                              LastName = result2.LastName,
                                                              Birthday = result2.Birthday,
                                                              Address = result2.Address,
                                                              Email = result2.Email,
                                                              IdContactType = result2.IdContactType,
                                                              ContactType = result2.ContactType,
                                                              IdPosition = result2.IdPosition,
                                                              Position = result2.Position,
                                                              ClientPermission = result2.ClientPermission,
                                                              Status = result2.Status
                                                          }).ToList().First(),
                               UserAcces = (from result3 in db.GNListUserAcces(result.IdUser, null).ToList()
                                            select new MUserAcces
                                            {
                                                IdOption = result3.IdOption,
                                                OptionName = result3.OptionName,
                                                Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                                Create = result3.Create == null ? false : (bool)result3.Create,
                                                Search = result3.Search == null ? false : (bool)result3.Search,
                                                Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                                Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                                IdAssociated = result3.IdAssociated,
                                            }).ToList()
                           }).First();

                ObjUser.UserAccesPadre = (from result3 in db.GNListUserAcces(null, null).ToList()
                                          select new MUserAcces
                                          {
                                              IdOption = result3.IdOption,
                                              OptionName = result3.OptionName,
                                              Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                              Create = result3.Create == null ? false : (bool)result3.Create,
                                              Search = result3.Search == null ? false : (bool)result3.Search,
                                              Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                              Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                              IdAssociated = result3.IdAssociated,
                                          }).ToList();

                return View(ObjUser);
            }

        }
        // GET: User/Create
        public ActionResult AddUser()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                MUser ObjUser = new MUser();
                MMEnterprisesEntities db = new MMEnterprisesEntities();

                ObjUser.UserAccesPadre = (from result3 in db.GNListUserAcces(null, null).ToList()
                                          select new MUserAcces
                                          {
                                              IdOption = result3.IdOption,
                                              OptionName = result3.OptionName,
                                              Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                              Create = result3.Create == null ? false : (bool)result3.Create,
                                              Search = result3.Search == null ? false : (bool)result3.Search,
                                              Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                              Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                              IdAssociated = result3.IdAssociated,
                                          }).ToList();

                ObjUser.UserAcces = new List<MUserAcces>();

                if (TempData["Success"] != null)
                    ViewBag.SuccessSave = TempData["Success"];

                return View(ObjUser);
            }
        }

        [HttpPost]
        public ActionResult AddUser(MUser objUser)
        {
            string mensaje="";
            try
            {
                if (objUser.UserAcces == null)
                {
                    objUser.UserAcces = new List<MUserAcces>();
                }

                if (ModelState.IsValid)
                {
                    objUser.Status = true;
                    int IdUser = funGNTranuser(objUser, "I", ref mensaje);

                    if (IdUser > 0)
                    { 

                        //FALTA QUE LIMPIE LOS CAMPOS Y SOLO MUESTRE EL MENSAJE DE ViewBag.SuccessSave
                        //return  View();
                        TempData["Success"] = "Datos grabados exitosamente, Código de Usuario generado: (" + IdUser + ").";
                        return RedirectToAction("AddUser");
                    }
                    else
                    {

                        ViewBag.ErrorSave = "Error al grabar datos del Usuario " + (mensaje==""?"": ": " + mensaje);
                        return View(objUser);
                    }

                }
                else
                {

                    return View(objUser);
                }

            }
            catch (SqlException ex)
            {
                //throw;
                //string msg= "Error al grabar datos del Usuario: " + ex.Message;
                //ModelState.AddModelError("ErrorSave", msg);
                ViewBag.ErrorSave = "Error al grabar datos del Usuario: " + ex.Message;
                return View(objUser);
            }

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
        public ActionResult EditUser(string id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                MUser ObjUser = new MUser();
                MMEnterprisesEntities db = new MMEnterprisesEntities();

                ObjUser = (from result in db.GNListUser(Convert.ToInt32(id)).ToList()
                           select new MUser
                           {
                               IdUser = result.IdUser,
                               IdPerson = result.IdPerson,
                               Login = result.Login,
                               Status = result.Status,
                               Password = ObjUser.Desencriptar(result.Password),
                               StatusDesc = result.Status == true ? "Activo" : "Inactivo",
                               PersonEmployee = (MPerson)(from result2 in db.GNListPerson(result.IdPerson, null).ToList()
                                                          select new MPerson
                                                          {
                                                              IdPerson = result2.IdPerson,
                                                              IdPersonType = result2.IdPersonType,
                                                              PersonType = result2.PersonType,
                                                              IdIdentificationType = result2.IdIdentificationType,
                                                              IdentificationType = result2.IdentificationType,
                                                              NumIdentification = result2.NumIdentification,
                                                              Name = result2.Name,
                                                              LastName = result2.LastName,
                                                              Birthday = result2.Birthday,
                                                              Address = result2.Address,
                                                              Email = result2.Email,
                                                              IdContactType = result2.IdContactType,
                                                              ContactType = result2.ContactType,
                                                              IdPosition = result2.IdPosition,
                                                              Position = result2.Position,
                                                              ClientPermission = result2.ClientPermission,
                                                              Status = result2.Status
                                                          }).ToList().First(),

                               UserAcces = (from result3 in db.GNListUserAcces(result.IdUser, null).ToList()
                                            select new MUserAcces
                                            {
                                                IdOption = result3.IdOption,
                                                OptionName = result3.OptionName,
                                                Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                                Create = result3.Create == null ? false : (bool)result3.Create,
                                                Search = result3.Search == null ? false : (bool)result3.Search,
                                                Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                                Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                                IdAssociated = result3.IdAssociated,
                                            }).ToList()
                           }).First();

                ObjUser.UserAccesPadre = (from result3 in db.GNListUserAcces(null, null).ToList()
                                          select new MUserAcces
                                          {
                                              IdOption = result3.IdOption,
                                              OptionName = result3.OptionName,
                                              Visible = result3.Visible == null ? false : (bool)result3.Visible,
                                              Create = result3.Create == null ? false : (bool)result3.Create,
                                              Search = result3.Search == null ? false : (bool)result3.Search,
                                              Edit = result3.Edit == null ? false : (bool)result3.Edit,
                                              Delete = result3.Edit == null ? false : (bool)result3.Delete,
                                              IdAssociated = result3.IdAssociated,
                                          }).ToList();


                if (TempData["Success"] != null)
                    ViewBag.SuccessSave = TempData["Success"];

                return View(ObjUser);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult EditUser(MUser objUser)
        {
            string mensaje = "";
            try
            {
                if (objUser.UserAcces == null)
                {
                    objUser.UserAcces = new List<MUserAcces>();
                }

                if (ModelState.IsValid)
                {
                    int IdUser = funGNTranuser(objUser, "U", ref mensaje);

                    if (IdUser > 0)
                    {

                        TempData["Success"] = "Datos grabados exitosamente, Código de Usuario: (" + IdUser + ").";
                        return RedirectToAction("EditUser", new { id = objUser.IdUser });
                    }
                    else
                    {

                        ViewBag.ErrorSave = "Error al grabar datos del Usuario " + (mensaje == "" ? "" : ": " + mensaje);
                        return View(objUser);
                    }

                }
                else
                {

                    return View(objUser);
                }

            }
            catch (SqlException ex)
            {
                //throw;
                //string msg= "Error al grabar datos del Usuario: " + ex.Message;
                //ModelState.AddModelError("ErrorSave", msg);
                ViewBag.ErrorSave = "Error al grabar datos del Usuario: " + ex.Message;
                return View(objUser);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// /// <param optional name="IdAssociated"></param>
        /// <returns></returns>
        public ActionResult DetailMenuOption(int IdUser,int IdAssociated)
        {
        
            List<MUserAcces> ObjUser = new List<MUserAcces>();
            MMEnterprisesEntities db = new MMEnterprisesEntities();

            ObjUser = (from result3 in db.GNListUserAcces(IdUser, IdAssociated).ToList()
                       select new MUserAcces
                       {
                           IdOption = result3.IdOption,
                           OptionName = result3.OptionName,
                           Visible = result3.Visible == null ? false : (bool)result3.Visible,
                           Create = result3.Create == null ? false : (bool)result3.Create,
                           Search = result3.Search == null ? false : (bool)result3.Search,
                           Edit = result3.Edit == null ? false : (bool)result3.Edit,
                           Delete = result3.Edit == null ? false : (bool)result3.Delete,
                           IdAssociated = result3.IdAssociated,
                       }).ToList();

          return   Json(ObjUser, JsonRequestBehavior.AllowGet);

        }

        private int funGNTranuser(MUser objUser, string TransactionType, ref string Mensaje)
        {
            try
            {
                MMEnterprisesEntities db = new MMEnterprisesEntities();

                int IdUser;
                int SqlResult;

                SqlParameter paramOutIdUsuario = new SqlParameter();
                paramOutIdUsuario.ParameterName = "@IdUser";
                paramOutIdUsuario.SqlDbType = System.Data.SqlDbType.Int;
                paramOutIdUsuario.Direction = System.Data.ParameterDirection.InputOutput;
                paramOutIdUsuario.Value = objUser.IdUser;



                SqlResult = db.Database.ExecuteSqlCommand("GNTranUser @IdPerson, @strLogin , @strPassword, @TransactionType, @IdUser OUT, @btStatus ",
                       new SqlParameter[]{
                                new SqlParameter("@TransactionType", TransactionType),
                                paramOutIdUsuario,
                                new SqlParameter("@IdPerson", objUser.IdPerson),
                                new SqlParameter("@strLogin",objUser.Login),
                                new SqlParameter("@strPassword", objUser.Encriptar(objUser.Password)),
                                new SqlParameter("@btStatus", objUser.Status)
                        }
                    );

                IdUser = Int32.Parse(paramOutIdUsuario.Value.ToString());
                if (IdUser != 0)
                {

                    foreach (var item in objUser.UserAcces)
                    {

                        //ObjectParameter paramOutIdContact = new ObjectParameter("IdContact", typeof(int));
                        SqlParameter paramOutIdContact = new SqlParameter("@IdContact", System.Data.SqlDbType.Int);
                        paramOutIdContact.Direction = System.Data.ParameterDirection.Output;

                        SqlResult = db.Database.ExecuteSqlCommand("GNTranUserAcces @IdUser, @IdOption, @blnVisible " +
                                                                  ", @blnCreate, @blnSearch, @blnEdit, @blnDelete ",
                           new SqlParameter[]{
                                    new SqlParameter("@IdUser", IdUser),
                                    new SqlParameter("@IdOption", item.IdOption),
                                    new SqlParameter("@blnVisible", item.Visible),
                                    new SqlParameter("@blnCreate", item.Create),
                                    new SqlParameter("@blnSearch", item.Search),
                                    new SqlParameter("@blnEdit", item.Edit),
                                    new SqlParameter("@blnDelete", item.Delete)
                            }
                        );
                    }
                }
                return IdUser;
            }
            catch (SqlException ex)
            {
                Mensaje= ex.Message;
                return 0;
            }
        }

        public ActionResult Close()
        {
            Session.RemoveAll();

            return RedirectToAction("Login", "User");
        }
    }
}

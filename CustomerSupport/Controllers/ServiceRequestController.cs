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
    public class ServiceRequestController : Controller
    {
        // GET: ServiceRequest
        public ActionResult ListServiceRequest()
        {
            return View();
        }

        public ActionResult GetListServiceRequest()
        {
            List<MServiceRequest> ListServiceRequest = new List<MServiceRequest>();
            MMEnterprisesEntities db = new MMEnterprisesEntities();
            ListServiceRequest = fnListServiceRequest(null, null,null,null,null);
            return Json(ListServiceRequest, JsonRequestBehavior.AllowGet);

        }

        // GET: ServiceRequest/AddServiceRequest
        public ActionResult AddServiceRequest()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            MServiceRequest objServiceRequest = new MServiceRequest();
            objServiceRequest.listConstructionOption = new List<MServiceConstructionOption>();
            objServiceRequest.listTask = new List<MTask>();

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessSave = TempData["Success"];
            }

            return View(objServiceRequest);
        }

        // POST: ServiceRequest/AddServiceRequest
        [HttpPost]
        public ActionResult AddServiceRequest(MServiceRequest objServiceRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //valores por defecto
                    //......
                    //------------------

                    string mensaje = "";
                    int IdService = 0;
                    int resultDb = fnGNTranServiceRequest(objServiceRequest, "I", ref IdService, ref mensaje);

                    if (resultDb != 0)
                    {
                        TempData["Success"] = mensaje + "Nro. de servicio generado : (" + IdService + ").";
                        return RedirectToAction("AddEmployee");
                    }
                    else
                    {
                        ViewBag.ErrorSave = mensaje;
                        return View(objServiceRequest);
                    }
                }
                else
                {
                    return View(objServiceRequest);
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorSave = "Error al grabar datos de la solicitud de servicio: " + ex.Message;
                return View(objServiceRequest);
            }

        }

        public static List<MServiceRequest> fnListServiceRequest(int? IdServiceRequest, int? IdServiceType, int? IdServiceStatus = null, int? IdPerson = null, int? IdUser = null)
        {
            List<MServiceRequest> ListServiceRequest = new List<MServiceRequest>();
            MMEnterprisesEntities db = new MMEnterprisesEntities();

             ListServiceRequest = (from d in db.GNListServiceRequest(IdServiceRequest, IdServiceType, IdServiceStatus, IdPerson, IdUser).ToList()
            join c in db.VWListCatalog.Where(t => t.IdTable == "SERVICESTATUS").ToList() on d.IdServiceStatus equals c.IdCatalogDetail
                        select new MServiceRequest
                          {
                              IdServiceRequest = d.IdServiceRequest,
                              IdServiceType = d.IdServiceType,
                              ServiceType = d.ServiceType,
                              IdServiceStatus = d.IdServiceStatus,
                              ServiceStatus = c.DetailDesc,
                              IdPerson = d.IdPerson,
                              PersonClient = (MPerson)(from result2 in db.GNListPerson(d.IdPerson, null, null).ToList()
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
                                     RegisterDate = d.RegisterDate
                                 }).ToList();

            return ListServiceRequest;

        }

        public static int fnGNTranServiceRequest(MServiceRequest objServiceRequest, string TransactionType, ref int IdServiceRequest, ref string Mensaje)
        {
            try
            {
                MMEnterprisesEntities db = new MMEnterprisesEntities();

                int SqlResultService;
                int SqlResult;

                SqlParameter paramOutIdServiceRequest = new SqlParameter();
                paramOutIdServiceRequest.ParameterName = "@IdServiceRequest";
                paramOutIdServiceRequest.SqlDbType = System.Data.SqlDbType.Int;
                paramOutIdServiceRequest.Direction = System.Data.ParameterDirection.InputOutput;
                paramOutIdServiceRequest.Value = objServiceRequest.IdServiceRequest;

                //SqlParameter paramIdContactType = new SqlParameter();
                //paramIdContactType.ParameterName = "@IdContactType";
                //paramIdContactType.SqlDbType = System.Data.SqlDbType.Int;
                //paramIdContactType.Direction = System.Data.ParameterDirection.Input;
                //paramIdContactType.IsNullable = true;
                //if (objPerson.IdContactType != null)
                //{
                //    paramIdContactType.Value = objPerson.IdContactType;
                //}
                //else
                //{
                //    paramIdContactType.Value = DBNull.Value;
                //}


                SqlResultService = db.Database.ExecuteSqlCommand("GNTranServiceRequest @TransactionType, @IdServiceRequest OUT, @IdServiceType, @IdServiceStatus, @IdPerson " +
                                                        " ,@IdContactType, @IdPropertyType ,@Address, @Price, @ClosingCost, @MonthlyIncome, @DebtPayment " +
                                                        " ,@Piti, @Ratios, @EstimatedValue, @LoanAmount, @CurrentDebt, @Assets, @Beneficiaries " +
                                                        " ,@Process, @Wish, @Plane, @Financing, @Note, @IdUser ",
                        new SqlParameter[]{
                            new SqlParameter("@TransactionType", TransactionType),
                            paramOutIdServiceRequest,
                            new SqlParameter("@IdServiceType", objServiceRequest.IdServiceType),
                            new SqlParameter("@IdServiceStatus", objServiceRequest.IdServiceStatus),
                            new SqlParameter("@IdPerson", objServiceRequest.IdPerson),
                            new SqlParameter("@IdContactType", objServiceRequest.IdContactType),
                            new SqlParameter("@IdPropertyType", objServiceRequest.IdPropertyType),
                            new SqlParameter("@Address", objServiceRequest.Address),
                            new SqlParameter("@Price", objServiceRequest.Price),
                            new SqlParameter("@ClosingCost", objServiceRequest.ClosingCost),
                            new SqlParameter("@MonthlyIncome", objServiceRequest.MonthlyIncome),
                            new SqlParameter("@DebtPayment", objServiceRequest.DebtPayment),
                            new SqlParameter("@Piti", objServiceRequest.Piti),
                            new SqlParameter("@Ratios", objServiceRequest.Ratios),
                            new SqlParameter("@EstimatedValue", objServiceRequest.EstimatedValue),
                            new SqlParameter("@LoanAmount", objServiceRequest.LoanAmount),
                            new SqlParameter("@CurrentDebt", objServiceRequest.CurrentDebt),
                            new SqlParameter("@Assets", objServiceRequest.Assets),
                            new SqlParameter("@Beneficiaries", objServiceRequest.Beneficiaries),
                            new SqlParameter("@Process", objServiceRequest.Process),
                            new SqlParameter("@Wish", objServiceRequest.Wish),
                            new SqlParameter("@Plane", objServiceRequest.Plane),
                            new SqlParameter("@Financing", objServiceRequest.Financing),
                            new SqlParameter("@Note", objServiceRequest.Note),
                            new SqlParameter("@IdUser", objServiceRequest.IdUser)
                        }
                    );

                IdServiceRequest = Int32.Parse(paramOutIdServiceRequest.Value.ToString());

                if (IdServiceRequest != 0)
                {
                    //OPCIONES DE CONSTRUCCION
                    if (objServiceRequest.listConstructionOption != null)
                    {

                        //si va a actualizar, se eliminan las opciones de construccion, para volverlas a insertar
                        if (TransactionType == "U")
                        {
                            SqlResult = db.Database.ExecuteSqlCommand("GNTranServiceConstructionOption @TransactionType, @IdServiceRequest, @IdConstructionOption ",
                                new SqlParameter[]{
                                    new SqlParameter("@TransactionType", TransactionType),
                                    new SqlParameter("@IdServiceRequest", IdServiceRequest),
                                    new SqlParameter("@IdConstructionOption", DBNull.Value)
                                }
                            );
                        }

                        //Inserta las opciones de construccion
                        foreach (var item in objServiceRequest.listConstructionOption)
                        {
                            SqlResult = db.Database.ExecuteSqlCommand("GNTranServiceConstructionOption @TransactionType, @IdServiceRequest, @IdConstructionOption ",
                                new SqlParameter[]{
                                    new SqlParameter("@TransactionType", TransactionType),
                                    new SqlParameter("@IdServiceRequest", IdServiceRequest),
                                    new SqlParameter("@IdConstructionOption", item.IdConstructionOption)
                                }
                            );
                        }
                    }

                    //ACTIVIDAD/CITA
                    if (objServiceRequest.listTask != null)
                    {
                        int IdTask;

                        //INVOLUCRADOS EN LA TASK
                        //Si esta actualizando, elimina los involucrados para volver a insertar (Por ahora 1 Solo)
                        if (TransactionType == "U")
                        {
                            SqlResult = db.Database.ExecuteSqlCommand("GNTranPersonTask @TransactionType, @IdTask, @IdPerson ",
                                new SqlParameter[]{
                                new SqlParameter("@TransactionType", TransactionType),
                                new SqlParameter("@IdTask", ((MTask)objServiceRequest.listTask.First()).IdTask),
                                new SqlParameter("@IdPerson", DBNull.Value)
                                }
                            );
                        }

                        //(Inserta/Actualiza) las actividades del Servicio
                        foreach (var item in objServiceRequest.listTask)
                        {
                            SqlParameter paramOutIdTask = new SqlParameter();
                            paramOutIdTask.ParameterName = "@IdTask";
                            paramOutIdTask.SqlDbType = System.Data.SqlDbType.Int;
                            paramOutIdTask.Direction = System.Data.ParameterDirection.InputOutput;
                            paramOutIdTask.Value = item.IdTask;

                            SqlResult = db.Database.ExecuteSqlCommand("GNTranTask @TransactionType, @IdTask OUT, @IdUser, @Activity " +
                                                                    " ,@DateIni, @DateEnd, @HourIni, @HourEnd, @Place, @Status ",
                                new SqlParameter[]{
                                    new SqlParameter("@TransactionType", TransactionType),
                                    paramOutIdTask,
                                    new SqlParameter("@IdUser", item.IdUser),
                                    new SqlParameter("@Activity", item.Activity),
                                    new SqlParameter("@DateIni", item.DateIni),
                                    new SqlParameter("@DateEnd", item.DateEnd),
                                    new SqlParameter("@HourIni", item.HourIni),
                                    new SqlParameter("@HourEnd", item.HourEnd),
                                    new SqlParameter("@Place", item.Place),
                                    new SqlParameter("@Status", item.Status)
                                }
                            );

                            IdTask = Int32.Parse(paramOutIdServiceRequest.Value.ToString());


                            if (IdTask != 0) 
                            {
                                //Se asocia la actividad con el servicio si esta insertando
                                if (TransactionType == "I")
                                {
                                    SqlResult = db.Database.ExecuteSqlCommand("GNTranServiceRequestTask @TransactionType, @IdTask, @IdServiceRequest ",
                                        new SqlParameter[]{
                                        new SqlParameter("@TransactionType", TransactionType),
                                        new SqlParameter("@IdTask", IdTask),
                                        new SqlParameter("@IdServiceRequest", IdServiceRequest)
                                        }
                                    );
                                }

                                //INVOLUCRADOS EN LA TASK                                
                                //Inserta los involucarados
                                SqlResult = db.Database.ExecuteSqlCommand("GNTranPersonTask @TransactionType, @IdTask, @IdPerson ",
                                    new SqlParameter[]{
                                            new SqlParameter("@TransactionType", TransactionType),
                                            new SqlParameter("@IdTask", IdTask),
                                            new SqlParameter("@IdPerson", item.IdPersonEmployee)
                                    }
                                );

                            }
                        }
                    }

                    Mensaje = "Datos grabados exitosamente.";
                }
                else
                {
                    Mensaje = "No se pudo realizar la transaccion, intente nuevamente.";
                }

                return SqlResultService;

            }
            catch (SqlException ex)
            {
                Mensaje = "Error al grabar datos: " + ex.Message;
                return 0;
            }
        }


    }
}
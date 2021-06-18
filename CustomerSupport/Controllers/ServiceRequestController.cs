﻿using System;
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
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //valores por defecto
                    objServiceRequest.IdUser = ((MUser)Session["Usuario"]).IdUser;
                    //------------------

                    string mensaje = "";
                    int IdService = 0;
                    int resultDb = fnGNTranServiceRequest(objServiceRequest, "I", ref IdService, ref mensaje);

                    if (resultDb != 0)
                    {
                        TempData["Success"] = mensaje + "Nro. de servicio generado : (" + IdService + ").";
                        return RedirectToAction("AddServiceRequest");
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

                SqlParameter paramIdContactType = new SqlParameter();
                paramIdContactType.ParameterName = "@IdContactType";
                if (objServiceRequest.IdContactType != null)
                {
                    paramIdContactType.Value = objServiceRequest.IdContactType;
                }
                else
                {
                    paramIdContactType.Value = DBNull.Value;
                }
                SqlParameter paramIdPropertyType = new SqlParameter();
                paramIdPropertyType.ParameterName = "@IdPropertyType";
                if (objServiceRequest.IdPropertyType != null)
                {
                    paramIdPropertyType.Value = objServiceRequest.IdPropertyType;
                }
                else
                {
                    paramIdPropertyType.Value = DBNull.Value;
                }
                SqlParameter paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@Price";
                if (objServiceRequest.Price != null)
                {
                    paramPrice.Value = objServiceRequest.Price;
                }
                else
                {
                    paramPrice.Value = DBNull.Value;
                }
                SqlParameter paramDownPayment = new SqlParameter();
                paramDownPayment.ParameterName = "@DownPayment";
                if (objServiceRequest.DownPayment != null)
                {
                    paramDownPayment.Value = objServiceRequest.DownPayment;
                }
                else
                {
                    paramDownPayment.Value = DBNull.Value;
                }
                SqlParameter paramClosingCost = new SqlParameter();
                paramClosingCost.ParameterName = "@ClosingCost";
                if (objServiceRequest.ClosingCost != null)
                {
                    paramClosingCost.Value = objServiceRequest.ClosingCost;
                }
                else
                {
                    paramClosingCost.Value = DBNull.Value;
                }
                SqlParameter paramMonthlyIncome = new SqlParameter();
                paramMonthlyIncome.ParameterName = "@MonthlyIncome";
                if (objServiceRequest.MonthlyIncome != null)
                {
                    paramMonthlyIncome.Value = objServiceRequest.MonthlyIncome;
                }
                else
                {
                    paramMonthlyIncome.Value = DBNull.Value;
                }
                SqlParameter paramDebtPayment = new SqlParameter();
                paramDebtPayment.ParameterName = "@DebtPayment";
                if (objServiceRequest.DebtPayment != null)
                {
                    paramDebtPayment.Value = objServiceRequest.DebtPayment;
                }
                else
                {
                    paramDebtPayment.Value = DBNull.Value;
                }
                SqlParameter paramPiti = new SqlParameter();
                paramPiti.ParameterName = "@Piti";
                if (objServiceRequest.Piti != null)
                {
                    paramPiti.Value = objServiceRequest.Piti;
                }
                else
                {
                    paramPiti.Value = DBNull.Value;
                }
                SqlParameter paramRatios = new SqlParameter();
                paramRatios.ParameterName = "@Ratios";
                if (objServiceRequest.Ratios != null)
                {
                    paramRatios.Value = objServiceRequest.Ratios;
                }
                else
                {
                    paramRatios.Value = DBNull.Value;
                }
                SqlParameter paramEstimatedValue = new SqlParameter();
                paramEstimatedValue.ParameterName = "@EstimatedValue";
                if (objServiceRequest.EstimatedValue != null)
                {
                    paramEstimatedValue.Value = objServiceRequest.EstimatedValue;
                }
                else
                {
                    paramEstimatedValue.Value = DBNull.Value;
                }
                SqlParameter paramLoanAmount = new SqlParameter();
                paramLoanAmount.ParameterName = "@LoanAmount";
                if (objServiceRequest.LoanAmount != null)
                {
                    paramLoanAmount.Value = objServiceRequest.LoanAmount;
                }
                else
                {
                    paramLoanAmount.Value = DBNull.Value;
                }
                SqlParameter paramCurrentDebt = new SqlParameter();
                paramCurrentDebt.ParameterName = "@CurrentDebt";
                if (objServiceRequest.CurrentDebt != null)
                {
                    paramCurrentDebt.Value = objServiceRequest.CurrentDebt;
                }
                else
                {
                    paramCurrentDebt.Value = DBNull.Value;
                }
                SqlParameter paramPlane = new SqlParameter();
                paramPlane.ParameterName = "@Plane";
                if (objServiceRequest.Plane != null)
                {
                    paramPlane.Value = objServiceRequest.Plane;
                }
                else
                {
                    paramPlane.Value = DBNull.Value;
                }
                SqlParameter paramFinancing = new SqlParameter();
                paramFinancing.ParameterName = "@Financing";
                if (objServiceRequest.Financing != null)
                {
                    paramFinancing.Value = objServiceRequest.Financing;
                }
                else
                {
                    paramFinancing.Value = DBNull.Value;
                }

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                if (objServiceRequest.Address != null)
                {
                    paramAddress.Value = objServiceRequest.Address;
                }
                else
                {
                    paramAddress.Value = DBNull.Value;
                }
                SqlParameter paramAssets = new SqlParameter();
                paramAssets.ParameterName = "@Assets";
                if (objServiceRequest.Assets != null)
                {
                    paramAssets.Value = objServiceRequest.Assets;
                }
                else
                {
                    paramAssets.Value = DBNull.Value;
                }
                SqlParameter paramBeneficiaries = new SqlParameter();
                paramBeneficiaries.ParameterName = "@Beneficiaries";
                if (objServiceRequest.Beneficiaries != null)
                {
                    paramBeneficiaries.Value = objServiceRequest.Beneficiaries;
                }
                else
                {
                    paramBeneficiaries.Value = DBNull.Value;
                }
                SqlParameter paramProcess = new SqlParameter();
                paramProcess.ParameterName = "@Process";
                if (objServiceRequest.Process != null)
                {
                    paramProcess.Value = objServiceRequest.Process;
                }
                else
                {
                    paramProcess.Value = DBNull.Value;
                }
                SqlParameter paramWish = new SqlParameter();
                paramWish.ParameterName = "@Wish";
                if (objServiceRequest.Wish != null)
                {
                    paramWish.Value = objServiceRequest.Wish;
                }
                else
                {
                    paramWish.Value = DBNull.Value;
                }
                SqlParameter paramNote = new SqlParameter();
                paramNote.ParameterName = "@Note";
                if (objServiceRequest.Note != null)
                {
                    paramNote.Value = objServiceRequest.Note;
                }
                else
                {
                    paramNote.Value = DBNull.Value;
                }

                SqlResultService = db.Database.ExecuteSqlCommand("GNTranServiceRequest @TransactionType, @IdServiceRequest OUT, @IdServiceType, @IdServiceStatus, @IdPerson " +
                                                        " ,@IdContactType, @IdPropertyType ,@Address, @Price, @DownPayment, @ClosingCost, @MonthlyIncome, @DebtPayment " +
                                                        " ,@Piti, @Ratios, @EstimatedValue, @LoanAmount, @CurrentDebt, @Assets, @Beneficiaries " +
                                                        " ,@Process, @Wish, @Plane, @Financing, @Note, @IdUser ",
                        new SqlParameter[]{
                            new SqlParameter("@TransactionType", TransactionType),
                            paramOutIdServiceRequest,
                            new SqlParameter("@IdServiceType", objServiceRequest.IdServiceType),
                            new SqlParameter("@IdServiceStatus", objServiceRequest.IdServiceStatus),
                            new SqlParameter("@IdPerson", objServiceRequest.IdPerson),
                            paramIdContactType,
                            paramIdPropertyType,
                            paramAddress,
                            paramPrice,
                            paramDownPayment,
                            paramClosingCost,
                            paramMonthlyIncome,
                            paramDebtPayment,
                            paramPiti,
                            paramRatios,
                            paramEstimatedValue,
                            paramLoanAmount,
                            paramCurrentDebt,
                            paramAssets,
                            paramBeneficiaries,
                            paramProcess,
                            paramWish,
                            paramPlane,
                            paramFinancing,
                            paramNote,
                            new SqlParameter("@IdUser", objServiceRequest.IdUser)
                        }
                    );

                IdServiceRequest = Int32.Parse(paramOutIdServiceRequest.Value.ToString());

                if (IdServiceRequest != 0)
                {
                    //OPCIONES DE CONSTRUCCION
                    if (objServiceRequest.listConstructionOption != null)
                    {
                        if (objServiceRequest.listConstructionOption.Count()>0)
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
                    }

                    //ACTIVIDAD/CITA
                    if (objServiceRequest.listTask != null)
                    {
                        if (objServiceRequest.listTask.Count()>0)
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
                                        new SqlParameter("@IdUser", objServiceRequest.IdUser), //Debe ser item.IdUser si se graba desde otra vista
                                        new SqlParameter("@Activity", item.Activity),
                                        new SqlParameter("@DateIni", item.DateIni),
                                        new SqlParameter("@DateEnd", item.DateIni), //Debe ser item.DateEnd cuando el campo en la vista esta habilitado
                                        new SqlParameter("@HourIni", item.HourIni),
                                        new SqlParameter("@HourEnd", item.HourIni), //Debe ser item.HourEnd cuando el campo en la vista esta habilitado
                                        new SqlParameter("@Place", item.Place),
                                        new SqlParameter("@Status", true) //Debe ser item.Status cuando el campo en la vista esta habilitado
                                    }
                                );

                                IdTask = Int32.Parse(paramOutIdTask.Value.ToString());


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
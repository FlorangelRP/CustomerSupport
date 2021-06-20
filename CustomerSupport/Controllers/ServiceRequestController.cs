using System;
using System.Collections.Generic;
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

        public ActionResult AddServiceRequest()
        {
            return View();
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

        // GET: Employee/DetailServiceRequest/5
        public ActionResult DetailServiceRequest(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            MServiceRequest objServiceRequest = new MServiceRequest();
            objServiceRequest = fnListServiceRequest(id,null,null,null,null).First();
            return View(objServiceRequest);
        }
    }
}
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

            //ListServiceRequest = (from result in db.GNListServiceRequest(null).ToList()
            //            select new MUser
            //            {
            //                IdServiceRequest = result.IdServiceRequest
            //                //,PersonClient = ((MPerson)(from result2 in db.GNListPerson(result.IdPerson, null)
            //                //                  select new MPerson
            //                //                  {
            //                //                      IdPerson = result2.IdPerson,
            //                //                      IdPersonType = result2.IdPersonType,
            //                //                      PersonType = result2.PersonType,
            //                //                      IdIdentificationType = result2.IdIdentificationType,
            //                //                      IdentificationType = result2.IdentificationType,
            //                //                      NumIdentification = result2.NumIdentification,
            //                //                      Name = result2.Name,
            //                //                      LastName = result2.LastName,
            //                //                      Birthday = result2.Birthday,
            //                //                      Address = result2.Address,
            //                //                      Email = result2.Email,
            //                //                      IdContactType = result2.IdContactType,
            //                //                      ContactType = result2.ContactType,
            //                //                      IdPosition = result2.IdPosition,
            //                //                      Position = result2.Position,
            //                //                      ClientPermission = result2.ClientPermission,
            //                //                      Status = result2.Status
            //                //                  }))
            //            }).ToList();

            return Json(ListServiceRequest, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddServiceRequest()
        {
            return View();
        }
    }
}
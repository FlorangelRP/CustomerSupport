using CustomerSupport.BDContext;
using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CustomerSupport.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult ListClient()
        {
            return View();
        }

        public ActionResult GetListClient()
        {
            List<MPerson> ListPerson = new List<MPerson>();
            ListPerson = PersonController.fnListPerson(null, 1); //1-cliente

            return Json(ListPerson, JsonRequestBehavior.AllowGet); 
        }

        // GET: Client/DetailClient/5
        public ActionResult DetailClient(int id)
        {
            MPerson objPersonClient = new MPerson();
            objPersonClient = PersonController.fnListPerson(id, 1).First(); //1-cliente
            return View(objPersonClient);
        }

        // GET: Client/AddClient
        public ActionResult AddClient()
        {
            MPerson objPersonClient = new MPerson();
            objPersonClient.Birthday = DateTime.Now;
            objPersonClient.listPersonContact = new List<MPersonContact>();

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessSave = TempData["Success"];
            }

            return View(objPersonClient);
        }

        // POST: Client/AddClient
        [HttpPost]
        public ActionResult AddClient(MPerson objPersonClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //valores por defecto
                    objPersonClient.Status = true; //activo
                    objPersonClient.IdPersonType = 1; //tipo cliente

                    string mensaje = "";
                    int resultDb = PersonController.fnGNTranPerson(objPersonClient, "I", ref mensaje);

                    if (resultDb != 0)
                    {
                        TempData["Success"] = mensaje;
                        return RedirectToAction("AddClient");
                    }
                    else
                    {
                        ViewBag.ErrorSave = mensaje;
                        return View(objPersonClient);
                    }
                }
                else
                {
                    return View(objPersonClient);
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorSave = "Error al grabar datos del cliente: " + ex.Message;
                return View(objPersonClient);
            }
        }


        // GET: Client/EditClient/5
        public ActionResult EditClient(int id)
        {
            MPerson objPersonClient = new MPerson();
            objPersonClient = PersonController.fnListPerson(id, 1).First(); //1-cliente

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessSave = TempData["Success"];
            }

            return View(objPersonClient);
        }

        // POST: Client/EditClient
        [HttpPost]
        public ActionResult EditClient(MPerson objPersonClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //valores por defecto
                    objPersonClient.IdPersonType = 1; //tipo cliente

                    string mensaje = "";
                    int resultDb = PersonController.fnGNTranPerson(objPersonClient, "U", ref mensaje);

                    if (resultDb != 0)
                    {
                        TempData["Success"] = mensaje;
                        return RedirectToAction("EditClient", new { id = objPersonClient.IdPerson });
                    }
                    else
                    {
                        ViewBag.ErrorSave = mensaje;
                        return View(objPersonClient);
                    }
                }
                else
                {
                    return View(objPersonClient);
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorSave = "Error al grabar datos del cliente: " + ex.Message;
                return View(objPersonClient);
            }

        }


    }
}

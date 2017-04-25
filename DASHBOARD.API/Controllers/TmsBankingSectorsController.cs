using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsBankingSectorsController : ApiController
    {
        private TmsBankingSectorsBll _bankingSectorsBll;
        public TmsBankingSectorsController()
        {
            _bankingSectorsBll = new TmsBankingSectorsBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsBankingSectors")]
        [ResponseType(typeof(TMS_Banks_Sectors))]
        public IHttpActionResult GetAllBankingSectors()
        {
            var qry = _bankingSectorsBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsBankingSectors/GetBankingSectorsById/{id}")]
        [ResponseType(typeof(TMS_Banks_Sectors))]
        public IHttpActionResult GetBankingSectorsById(int id)
        {

            var contact = _bankingSectorsBll.GetById(id);
            if (contact.Any())
            {
                var qry = _bankingSectorsBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsBankingSectors/GetBankingSectorsByContext/{sValue}")]
        [ResponseType(typeof(TMS_Banks_Sectors))]
        public IHttpActionResult GetBankingSectorsByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _bankingSectorsBll.GetAll().Where(c => c.BankName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsBankingSectors")]
        [ResponseType(typeof(TMS_Banks_Sectors))]
        public IHttpActionResult Post(TMS_Banks_Sectors bankingSectors)
        {
            if (bankingSectors.BankName == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Bank Name field cannot be empty!" });
            }
            if (bankingSectors.BankLocation == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Bank Location field cannot be empty!" });
            }
            if (bankingSectors.AcctNo == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Acct. No date field cannot be empty!" });
            }
            if (bankingSectors.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (bankingSectors.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //assign default values before inserting
            bankingSectors.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                int c = _bankingSectorsBll.Insert(bankingSectors);
                if (c == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            else
            {
                return Json(new { Msg = "0" });

            }
        }

        // PUT: api/TmsBankingSectors/UpdateBankingSectors/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsBankingSectors/UpdateBankingSectors/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateBankingSectors(int id, TMS_Banks_Sectors bankingSectors)
        {
            //TODO: validate values before inserting
            if (bankingSectors.BankName == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Bank Name field cannot be empty!" });
            }
            if (bankingSectors.BankLocation == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Bank Location field cannot be empty!" });
            }
            if (bankingSectors.AcctNo == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Acct. No date field cannot be empty!" });
            }
            if (bankingSectors.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (bankingSectors.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //TODO: assign default values before inserting
            bankingSectors.CreationDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != bankingSectors.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _bankingSectorsBll.Update(bankingSectors);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteBankingSectorsExists(id))
                {
                    //return NotFound();
                    return Json(new { Msg = "0", Reason = "Exception!" });
                }
                else
                {
                    throw;
                }
            }
        }


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("DELETE")]
        [Route("api/TmsBankingSectors/DeleteBankingSectors/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBankingSectors(int id)
        {
            var contact = _bankingSectorsBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _bankingSectorsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteBankingSectorsExists(int id)
        {
            return _bankingSectorsBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

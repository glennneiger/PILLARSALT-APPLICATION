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
    public class AccBankController : ApiController
    {
        private AccBankBll _accBankBll;

        public AccBankController()
        {
            _accBankBll = new AccBankBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/AccBank")]
        [ResponseType(typeof(ACCBank))]
        public IHttpActionResult GetAllBank()
        {
            var qry = from d in _accBankBll.GetAll()
                      select new { d.Id, d.BankName, d.Active };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/AccBank/GetBankById/{id}")]
        [ResponseType(typeof(ACCBank))]
        public IHttpActionResult GetBankById(int id)
        {

            var contact = _accBankBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _accBankBll.GetById(id)
                          select new { d.Id, d.BankName, d.Active };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/AccBank/GetBankByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccBank/GetBankByContext/{sValue}")]
        [ResponseType(typeof(ACCBank))]
        public IHttpActionResult GetBankByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _accBankBll.GetAll().Where(c => c.BankName.Contains(sValue))
                          select new { d.Id, d.BankName, d.Active };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccBank")]
        [ResponseType(typeof(ACCBank))]
        public IHttpActionResult Post(ACCBank accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _accBankBll.Insert(accountsBankDetails);
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


        // PUT: api/AccAccountsBankDetails/UpdateAccountsBankDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/AccBank/UpdateBank")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateBank(int id, ACCBank accountsBankDetails)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != accountsBankDetails.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _accBankBll.Update(accountsBankDetails);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankMappingExists(id))
                {
                    //return NotFound();
                    return Json(new { Msg = "0", Reason = "No row affected!" });
                }
                else
                {
                    throw;
                }
            }
        }
        
        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("DELETE")]
        [Route("api/AccBank/DeleteBank/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _accBankBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _accBankBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool BankMappingExists(int id)
        {
            return _accBankBll.GetAll().Count(e => e.Id == id) > 0;
        }
        
    }
}

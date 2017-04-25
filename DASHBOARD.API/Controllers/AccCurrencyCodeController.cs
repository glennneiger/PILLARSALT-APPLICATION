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
    public class AccCurrencyCodeController : ApiController
    {
        private AccCurrencyCodeBll _currencyCodeBll;

        public AccCurrencyCodeController()
        {
            _currencyCodeBll = new AccCurrencyCodeBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/AccCurrencyCode")]
        [ResponseType(typeof (Acc_CurrencyCode))]
        public IHttpActionResult GetAllBankMapping()
        {
            var qry = from d in _currencyCodeBll.GetAll()
                select new {d.Id, d.Description, d.Active};

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/AccCurrencyCode/GetCurrencyCodeById/{id}")]
        [ResponseType(typeof (Acc_CurrencyCode))]
        public IHttpActionResult GetCurrencyCodeById(int id)
        {

            var contact = _currencyCodeBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _currencyCodeBll.GetById(id)
                    select new {d.Id, d.Description, d.Active};

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new {Msg = "0", Reason = "Record set is empty!"});

            }

        }

        //GET: api/AccAccountsBankDetails/GetAccountsBankDetailsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccCurrencyCode/GetCurrencyCodeByContext/{sValue}")]
        [ResponseType(typeof (Acc_CurrencyCode))]
        public IHttpActionResult GetCurrencyCodeByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _currencyCodeBll.GetAll().Where(c => c.Description.Contains(sValue))
                    select new {d.Id, d.Description, d.Active};

                return Ok(qry.ToList());
            }
            return Json(new {Msg = "0"});
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccCurrencyCode")]
        [ResponseType(typeof (Acc_CurrencyCode))]
        public IHttpActionResult Post(Acc_CurrencyCode accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _currencyCodeBll.Insert(accountsBankDetails);
                if (c == 1)
                {
                    return Json(new {Msg = "1"});
                }
                return Json(new {Msg = "0"});

            }
            else
            {
                return Json(new {Msg = "0"});

            }
        }


        // PUT: api/AccAccountsBankDetails/UpdateAccountsBankDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/AccCurrencyCode/UpdateCurrencyCode")]
        [ResponseType(typeof (void))]
        public IHttpActionResult UpdateCurrencyCode(int id, Acc_CurrencyCode accountsBankDetails)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new {Msg = "0"});
            }

            if (id != accountsBankDetails.Id)
            {
                //return BadRequest();
                return Json(new {Msg = "0"});
            }

            try
            {
                int s = _currencyCodeBll.Update(accountsBankDetails);
                if (s == 1)
                {
                    return Json(new {Msg = "1"});
                }
                return Json(new {Msg = "0"});

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankMappingExists(id))
                {
                    //return NotFound();
                    return Json(new {Msg = "0", Reason = "No row affected!"});
                }
                else
                {
                    throw;
                }
            }
        }


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("DELETE")]
        [Route("api/AccCurrencyCode/DeleteCurrencyCode/{id}")]
        [ResponseType(typeof (void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _currencyCodeBll.GetById(id);
            if (contact == null)
            {
                return Json(new {Msg = "0", Reason = "No record found!"});
            }
            int d = _currencyCodeBll.Delete(id);
            if (d == 1)
            {
                return Json(new {Msg = "1", Reason = "Record Deleted!"});
            }
            return Json(new {Msg = "0", Reason = "Deleted Failed!"});
        }



        private bool BankMappingExists(int id)
        {
            return _currencyCodeBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }

}

    

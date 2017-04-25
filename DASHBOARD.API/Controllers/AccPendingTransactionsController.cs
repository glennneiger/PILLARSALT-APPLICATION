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
    public class AccPendingTransactionsController : ApiController
    {
        private AccPendingTransactionsBll _PendingTransactionBll;

        public AccPendingTransactionsController()
        {
            _PendingTransactionBll = new AccPendingTransactionsBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/AccPendingTransactions")]
        [ResponseType(typeof(Acc_Pending_Transactions))]
        public IHttpActionResult GetAllPendingTransactions()
        {
            var qry = from d in _PendingTransactionBll.GetAll()
                      select new { d.Id, d.AccountNumber, d.Active };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/AccPendingTransactions/GetPendingTransactionsById/{id}")]
        [ResponseType(typeof(Acc_Pending_Transactions))]
        public IHttpActionResult GetPendingTransactionsById(int id)
        {

            var contact = _PendingTransactionBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _PendingTransactionBll.GetById(id)
                          select new { d.Id, d.AccountNumber, d.Active };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/AccAccountsBankDetails/GetAccountsBankDetailsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccPendingTransactions/GetCurrencyCodeByContext/{sValue}")]
        [ResponseType(typeof(Acc_Pending_Transactions))]
        public IHttpActionResult GetPendingTransactionsByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _PendingTransactionBll.GetAll().Where(c => c.AccountNumber.Equals(sValue))
                          select new { d.Id, d.AccountNumber, d.Active };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccPendingTransactions")]
        [ResponseType(typeof(Acc_Pending_Transactions))]
        public IHttpActionResult Post(Acc_Pending_Transactions accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _PendingTransactionBll.Insert(accountsBankDetails);
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
        [Route("api/AccPendingTransactions/UpdatePendingTransactions")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCurrencyCode(int id, Acc_Pending_Transactions accountsBankDetails)
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
                int s = _PendingTransactionBll.Update(accountsBankDetails);
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
        [Route("api/AccPendingTransactions/DeletePendingTransactions/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _PendingTransactionBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _PendingTransactionBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool BankMappingExists(int id)
        {
            return _PendingTransactionBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }

}

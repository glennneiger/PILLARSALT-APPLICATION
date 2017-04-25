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
    public class AccountLogController : ApiController
    {
        private AccountLogBll _accountLogBll;
        public AccountLogController()
        {
            _accountLogBll = new AccountLogBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/AccountLog")]
        [ResponseType(typeof(AccountLog))]
        public IHttpActionResult GetAllBank()
        {
            var qry = from d in _accountLogBll.GetAll()
                      select new { d.Id, d.ApprovalComment, d.Active };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/AccountLog/GetAccountLogById/{id}")]
        [ResponseType(typeof(AccountLog))]
        public IHttpActionResult GetAccountLogById(int id)
        {

            var contact = _accountLogBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _accountLogBll.GetById(id)
                          select new { d.Id, d.ApprovalComment, d.Active };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/AccountLog/GetBankByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccountLog/GetAccountLogByContext/{sValue}")]
        [ResponseType(typeof(AccountLog))]
        public IHttpActionResult GetAccountLogByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _accountLogBll.GetAll().Where(c => c.ApprovalComment.Contains(sValue))
                          select new { d.Id, d.ApprovalComment, d.Active };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccountLog")]
        [ResponseType(typeof(AccountLog))]
        public IHttpActionResult Post(AccountLog accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _accountLogBll.Insert(accountsBankDetails);
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
        [Route("api/AccountLog/UpdateAccountLog")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAccountLog(int id, AccountLog accountsBankDetails)
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
                int s = _accountLogBll.Update(accountsBankDetails);
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
        [Route("api/AccountLog/DeleteAccountLog/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAccountLog(int id)
        {
            var contact = _accountLogBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _accountLogBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool BankMappingExists(int id)
        {
            return _accountLogBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }



    
}

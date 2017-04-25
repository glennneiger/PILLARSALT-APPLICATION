using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class AccountEntityController : ApiController
    {
        private AccountEntityBll _accountEntityBll;
        public AccountEntityController()
        {
            _accountEntityBll = new AccountEntityBll();
        }
       
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/AccountEntity")]
        [ResponseType(typeof(AccountEntity))]
        public IHttpActionResult GetAllAccountEntity()
        {
            var contact = _accountEntityBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.AccountEntityID,
                            a.AccountEntityName,
                            a.Entry,
                            a.EntityCode,
                            a.UserId,
                            a.Active,
                            a.GLBatchNo,
                            a.ReviewerId,
                            a.OverrideId,
                            a.IPAddress,
                            a.MacAddress,
                            a.AuthoriseId,
                            a.RelatorKey,
                            a.ApprovalEntry,
                            a.ModuleID,
                            a.StartModuleID,
                            a.CurrentStage,
                            a.CreationDate,
                            a.BranchId,
                            a.Notes,
                            a.Revision,
                            a.Token,
                            a.EditReason,
                            a.TokenOwner,
                            a.TokenManifestId,
                            a.DeclineId,
                            a.ReviewEntry,
                            a.DeclineReason,
                            a.ApprovalComment,
                            a.ReviewerComment,
                            a.UpdateLocker

                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.Entry);

            return Ok(contact.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/AccountEntity/GetAccountEntityById/{id}")]
        [ResponseType(typeof(AccountEntity))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetAccountEntityById(int id)
        {

            var contact = _accountEntityBll.GetById(id);
            if (contact != null)
            {
                var contact2 = _accountEntityBll.GetAll()
                    .Select(
                        a => new
                        {
                            a.AccountEntityID,
                            a.AccountEntityName,
                            a.Entry,
                            a.EntityCode,
                            a.UserId,
                            a.Active,
                            a.GLBatchNo,
                            a.ReviewerId,
                            a.OverrideId,
                            a.IPAddress,
                            a.MacAddress,
                            a.AuthoriseId,
                            a.RelatorKey,
                            a.ApprovalEntry,
                            a.ModuleID,
                            a.StartModuleID,
                            a.CurrentStage,
                            a.CreationDate,
                            a.BranchId,
                            a.Notes,
                            a.Revision,
                            a.Token,
                            a.EditReason,
                            a.TokenOwner,
                            a.TokenManifestId,
                            a.DeclineId,
                            a.ReviewEntry,
                            a.DeclineReason,
                            a.ApprovalComment,
                            a.ReviewerComment,
                            a.UpdateLocker
                        }
                    )
                    .Where(c => c.AccountEntityID == id);

                return Ok(contact2);
            }
            else
            {
                return Json(new { Msg = "0" });

            }

        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/AccountEntity/GetAccountEntityByContext/{sValue}")]
        [ResponseType(typeof(AccountEntity))]
        public IHttpActionResult GetAccountEntityByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _accountEntityBll.GetAll().Where(c => c.AccountEntityName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        c =>
                            new
                            {
                                c.AccountEntityID,
                                c.AccountEntityName,
                                c.Active,
                                c.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccountEntity")]
        [ResponseType(typeof(AccountEntity))]
        public IHttpActionResult Post(AccountEntity accountEntity)
        {
            if (ModelState.IsValid)
            {
                int c = _accountEntityBll.Insert(accountEntity);
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


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("POST")]
        [Route("api/crmcontact/UpdateCrmContact/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateContact(int id, AccountEntity accountEntity)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != accountEntity.AccountEntityID)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _accountEntityBll.Update(accountEntity);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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
        [Route("api/crmcontact/DeleteCrmContact/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteContact(int id)
        {
            var contact = _accountEntityBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _accountEntityBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool ContactExists(int id)
        {
            return _accountEntityBll.GetAll().Count(e => e.AccountEntityID == id) > 0;
        }

    }
}

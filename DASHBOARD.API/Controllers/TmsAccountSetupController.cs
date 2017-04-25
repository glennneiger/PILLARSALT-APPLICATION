using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAccountSetupController : ApiController
    {
        private TmsAccountSetupBll _objtmsAccountSetpBll;

        public TmsAccountSetupController()
        {
            _objtmsAccountSetpBll = new TmsAccountSetupBll();

        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAccountSetup")]
        [ResponseType(typeof(TMS_Acct_Setup))]
        public IHttpActionResult GetAllAccountSetup()
        {
            var contact = _objtmsAccountSetpBll.GetAll()
                .Select(
                    c =>
                        new
                        {
                            c.Id,
                            c.TypeofAccount,
                            c.AcctType_Id,
                            c.CreationDate,
                            c.ModuleID,
                            c.CurrentStage,
                            c.UserId,
                            c.ReviewerId,
                            c.OverrideId,
                            c.AuthoriseId,
                            c.Active,
                            c.RelatorKey,
                            c.IPAddress,
                            c.MacAddress,
                            c.Entry,
                            c.ApprovalEntry,
                            c.StartModuleID,
                            c.BranchId,
                            c.Notes,
                            c.Revision,
                            c.Token,
                            c.EditReason,
                            c.TokenOwner,
                            c.TokenManifestId,
                            c.DeclineId,
                            c.ReviewEntry,
                            c.DeclineReason,
                            c.ApprovalComment,
                            c.ReviewerComment,
                            c.UpdateLocker
                        }).OrderBy(c => c.Entry);

            var qry = from p in contact
                      join d in contact on p.Id equals d.Id
                      select new
                      {
                          p,
                          d.IPAddress
                      };

            return Ok(contact.ToList());
        }

        //GET: api/TmsAuctionSetting/GetAuctionSettingByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAccountSetup/GettAccountSetupByContext/{sValue}")]
        [ResponseType(typeof(TMS_Acct_Setup))]
        public IHttpActionResult GettAccountSetupByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objtmsAccountSetpBll.GetAll().Where(c => c.AcctType_Id.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        c =>
                            new
                            {
                                c.Id,
                                c.AcctType_Id,
                                c.Active,
                                c.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsAccountSetup/GetAccountSetupById/{id}")]
        [ResponseType(typeof(TMS_Acct_Setup))]
        public IHttpActionResult GetAccountSetupById(int id)
        {
            var acctSetup = _objtmsAccountSetpBll.GetById(id);
            if (acctSetup != null)
            {
                var acctSetup2 = _objtmsAccountSetpBll.GetAll()
                    .Select(
                        c => new
                        {
                            c.Id,
                            c.TypeofAccount,
                            c.AcctType_Id,
                            c.CreationDate,
                            c.ModuleID,
                            c.CurrentStage,
                            c.UserId,
                            c.ReviewerId,
                            c.OverrideId,
                            c.AuthoriseId,
                            c.Active,
                            c.RelatorKey,
                            c.IPAddress,
                            c.MacAddress,
                            c.Entry,
                            c.ApprovalEntry,
                            c.StartModuleID,
                            c.BranchId,
                            c.Notes,
                            c.Revision,
                            c.Token,
                            c.EditReason,
                            c.TokenOwner,
                            c.TokenManifestId,
                            c.DeclineId,
                            c.ReviewEntry,
                            c.DeclineReason,
                            c.ApprovalComment,
                            c.ReviewerComment,
                            c.UpdateLocker
                        }
                    )
                    .Where(c => c.Id == id);

                return Ok(acctSetup2.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });

            }
        }


        //POST: api/TmsAccountSetup
        [AcceptVerbs("POST")]
        [Route("api/TmsAccountSetup")]
        [ResponseType(typeof(TMS_Acct_Setup))]
        public IHttpActionResult Post(TMS_Acct_Setup tmsAcctSetup)
        {
            if (tmsAcctSetup == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _objtmsAccountSetpBll.Insert(tmsAcctSetup);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });

                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Json(new { Msg = "0", Reason = "No row affected!" });
            }
        }
        // POST: api/crmcontact/UpdateAccountSetup/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsAccountSetup/UpdateAccountSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCrmContact(int id, TMS_Acct_Setup tmsAcctSetup)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != tmsAcctSetup.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _objtmsAccountSetpBll.Update(tmsAcctSetup);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsAcctSetupExists(id))
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

        // PUT: api/crmcontact/Delete/id
        [AcceptVerbs("DELETE")]
        [Route("api/TmsAccountSetup/DeleteAcctSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAcctSetup(int id)
        {
            var contact = _objtmsAccountSetpBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objtmsAccountSetpBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool TmsAcctSetupExists(int id)
        {
            return _objtmsAccountSetpBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

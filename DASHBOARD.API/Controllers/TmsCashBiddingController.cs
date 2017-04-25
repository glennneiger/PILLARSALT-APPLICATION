using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsCashBiddingController : ApiController
    {
        private TmsCashBiddingBll _objCashBiddingBll;
        public TmsCashBiddingController()
        {
            _objCashBiddingBll = new TmsCashBiddingBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsCashBidding")]
        [ResponseType(typeof(TMS_CashBidding))]
        public IHttpActionResult GetAllAccountSetup()
        {
            var advertiseCash = _objCashBiddingBll.GetAll().OrderBy(c => c.Entry);

            return Ok(advertiseCash.ToList());
        }

        //GET: api/TmsMachineBrand/GetMachineBrandByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsCashBidding/GetCashBiddingByContext/{sValue}")]
        [ResponseType(typeof(TMS_CashBidding))]
        public IHttpActionResult GetCashBiddingByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objCashBiddingBll.GetAll().Where(c => c.ApprovalComment.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        c =>
                            new
                            {
                                c.Id,
                                c.ApprovalComment,
                                c.Active
                            }).OrderBy(c => c.ApprovalComment).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Ok(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsCashBidding/GetAccountSetupById/{id}")]
        [ResponseType(typeof(TMS_CashBidding))]
        public IHttpActionResult GetAccountSetupById(int id)
        {
            var advertiseCash = _objCashBiddingBll.GetById(id);
            if (advertiseCash != null)
            {
                var advertiseCash2 = _objCashBiddingBll.GetAll()
                    .Select(
                        c => new
                        {
                            c.Id,
                            c.AccountId,
                            c.BidAmount,
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

                return Ok(advertiseCash2.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });

            }
        }


        //POST: api/tmsCashBidding
        [AcceptVerbs("POST")]
        [Route("api/TmsCashBidding/")]
        [ResponseType(typeof(TMS_CashBidding))]
        public IHttpActionResult Post(TMS_CashBidding tmsCashBidding)
        {
            if (tmsCashBidding == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _objCashBiddingBll.Insert(tmsCashBidding);
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
        [Route("api/TmsCashBidding/UpdateAccountSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCrmContact(int id, TMS_CashBidding tmsCashBidding)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != tmsCashBidding.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _objCashBiddingBll.Update(tmsCashBidding);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsCashBiddingExists(id))
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
        [Route("api/TmsCashBidding/DeleteAdvertiseCash/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCashBidding(int id)
        {
            var contact = _objCashBiddingBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objCashBiddingBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsCashBiddingExists(int id)
        {
            return _objCashBiddingBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }
}

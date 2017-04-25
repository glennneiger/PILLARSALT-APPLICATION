using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsDisbursementController : ApiController
    {
        private TmsDisbursementBll _objDisbursementBll;
        public TmsDisbursementController()
        {
            _objDisbursementBll = new TmsDisbursementBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsDisbursement")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult GetAllDisbursement()
        {
            var disburse = _objDisbursementBll.GetAll()
                .Select(
                    d =>
                        new
                        {
                            d.Id,
                            d.BidId,
                            d.AuctionPrice,
                            d.BidEndtimeDate,
                            d.CreationDate,
                            d.ModuleID,
                            d.CurrentStage,
                            d.UserId,
                            d.ReviewerId,
                            d.OverrideId,
                            d.AuthoriseId,
                            d.Active,
                            d.RelatorKey,
                            d.IPAddress,
                            d.MacAddress,
                            d.Entry,
                            d.ApprovalEntry,
                            d.StartModuleID,
                            d.BranchId,
                            d.Notes,
                            d.Revision,
                            d.Token,
                            d.EditReason,
                            d.TokenOwner,
                            d.TokenManifestId,
                            d.DeclineId,
                            d.ReviewEntry,
                            d.DeclineReason,
                            d.ApprovalComment,
                            d.ReviewerComment,
                            d.UpdateLocker
                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.Entry);

            return Ok(disburse.ToList());
        }

        //GET: api/TmsMachineBrand/GetMachineBrandByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBrand/GetMachineDisbursementByContext/{sValue}")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult GetMachineDisbursementByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objDisbursementBll.GetAll().Where(c => c.ApprovalComment.Contains(sValue)).ToList();
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

        [AcceptVerbs("GET")]
        [Route("api/TmsDisbursement/GetDisbursementById/{id}")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult GetDisbursementById(int id)
        {
            var disburse = _objDisbursementBll.GetAll().Where(c => c.Id.Equals(id));
            return Ok(disburse.ToList());
        }



        [AcceptVerbs("POST")]
        [Route("api/TmsDisbursement/InsertAdvertisedCash")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult InsertAdvertisedCash(TMS_Disbursment tmsDisbursment)
        {
            if (tmsDisbursment == null)
            {
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objDisbursementBll.Insert(tmsDisbursment);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0", Reason = "No row affected!" });
            }
        }


        [AcceptVerbs("POST")]
        [Route("api/TmsDisbursement/InsertAdvertisedCash")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult UpdateAdvertisedCash(int id, TMS_Disbursment tmsDisbursment)
        {
            if (tmsDisbursment == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsDisbursment.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objDisbursementBll.Update(tmsDisbursment);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsAdvertCashExists(id))
                {
                    //return NotFound();
                    return Ok(new { Msg = "0", Reason = "No row affected!" });
                }
                else
                {
                    throw;
                }
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("api/TmsDisbursement/DeleteDisbursement")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult DeleteDisbursement(int id)
        {
            var disburse = _objDisbursementBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objDisbursementBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertCashExists(int id)
        {
            return _objDisbursementBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }
}

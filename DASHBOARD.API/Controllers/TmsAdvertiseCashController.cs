using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAdvertiseCashController : ApiController
    {
        private TmsAdvertiseCashBll _objAdvertiseCashBll;
        public TmsAdvertiseCashController()
        {
            _objAdvertiseCashBll = new TmsAdvertiseCashBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertiseCash")]
        [ResponseType(typeof(TMS_Advertise_Cash))]
        public IHttpActionResult GetAllAccountSetup()
        {
            var advertiseCash = _objAdvertiseCashBll.GetAll()
                .Select(
                    c =>
                        new
                        {
                            c.Id,
                            c.AccountId,
                            c.CurrencyId,
                            c.AdvertAmount,
                            c.SellingPrice,
                            c.BidStartDate,
                            c.BidEndDate,
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
                            c.CreationDate,
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
                            c.UpdateLocker,
                            c.ReservedPrice
                        }).OrderBy(c => c.Entry);

            return Ok(advertiseCash.ToList());
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertiseCash/GetAdvertiseCashById/{id}")]
        [ResponseType(typeof(TMS_Advertise_Cash))]
        public IHttpActionResult GetAdvertiseCashById(int id)
        {
            var advertiseCash = _objAdvertiseCashBll.GetById(id);
            if (advertiseCash != null)
            {
                var advertiseCash2 = _objAdvertiseCashBll.GetAll()
                    .Select(
                        c => new
                        {
                            c.Id,
                            c.AccountId,
                            c.CurrencyId,
                            c.AdvertAmount,
                            c.SellingPrice,
                            c.BidStartDate,
                            c.BidEndDate,
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
                            c.CreationDate,
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
                            c.UpdateLocker,
                            c.ReservedPrice
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

        //GET: api/TmsAuctionSetting/GetAuctionSettingByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertiseCash/GetAdvertiseCashByContext/{sValue}")]
        [ResponseType(typeof(TMS_Advertise_Cash))]
        public IHttpActionResult GetAdvertiseCashByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objAdvertiseCashBll.GetAll().Where(c => c.ApprovalComment.Contains(sValue)).ToList();
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

            return Json(new { Msg = "0" });
        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsAdvertiseCash/")]
        [ResponseType(typeof(TMS_Advertise_Cash))]
        public IHttpActionResult Post(TMS_Advertise_Cash tmsAdvertiseCash)
        {

            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            if (!tmsAdvertiseCash.AccountId.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Account Id field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.CurrencyId.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Currency Id field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.AdvertAmount.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Advert Amount field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.SellingPrice.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Selling Price field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.BidStartDate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Bid Start Date field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.BidEndDate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Bid End Date field cannot be empty!" });
            }
            if (tmsAdvertiseCash.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (tmsAdvertiseCash.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }


            try
            {
                int s = _objAdvertiseCashBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsAdvertiseCash/UpdateAdvertiseCash/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAdvertiseCash(int id, TMS_Advertise_Cash tmsAdvertiseCash)
        {
            if (!tmsAdvertiseCash.AccountId.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Account Id field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.CurrencyId.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Currency Id field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.AdvertAmount.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Advert Amount field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.SellingPrice.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Selling Price field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.BidStartDate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Bid Start Date field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.BidEndDate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Bid End Date field cannot be empty!" });
            }
            if (tmsAdvertiseCash.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (tmsAdvertiseCash.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != tmsAdvertiseCash.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _objAdvertiseCashBll.Update(tmsAdvertiseCash);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsAdvertiseCashExists(id))
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
        [Route("api/TmsAdvertiseCash/DeleteAdvertiseCash/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAdvertiseCash(int id)
        {
            var contact = _objAdvertiseCashBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objAdvertiseCashBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool TmsAdvertiseCashExists(int id)
        {
            return _objAdvertiseCashBll.GetAll().Count(e => e.Id == id) > 0;
        }



    }
}

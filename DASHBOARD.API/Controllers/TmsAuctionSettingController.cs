using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAuctionSettingController : ApiController
    {
        private TmsAuctionSettingBll _objAuctionSettingBll;
        public TmsAuctionSettingController()
        {
            _objAuctionSettingBll = new TmsAuctionSettingBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAuctionSetting")]
        [ResponseType(typeof(TMS_Auction_Settings))]
        public IHttpActionResult GetAllAuctionSetting()
        {
            var advertiseCash = _objAuctionSettingBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.Description,
                            a.CreationDate,
                            a.ModuleID,
                            a.CurrentStage,
                            a.UserId,
                            a.ReviewerId,
                            a.OverrideId,
                            a.AuthoriseId,
                            a.Active,
                            a.RelatorKey,
                            a.IPAddress,
                            a.MacAddress,
                            a.Entry,
                            a.ApprovalEntry,
                            a.StartModuleID,
                            a.BranchId,
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

                        }).OrderBy(c => c.Entry);

            return Ok(advertiseCash.ToList());
        }

        //GET: api/TmsAuctionSetting/GetAuctionSettingByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAuctionSetting/GetAuctionSettingByContext/{sValue}")]
        [ResponseType(typeof(TMS_Auction_Settings))]
        public IHttpActionResult GetAuctionSettingByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objAuctionSettingBll.GetAll().Where(c => c.Description.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        c =>
                            new
                            {
                                c.Id,
                                c.Description,
                                c.Active
                            }).OrderBy(c => c.Description).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsAuctionSetting/GetAccountSetupById/{id}")]
        [ResponseType(typeof(TMS_Auction_Settings))]
        public IHttpActionResult GetAccountSetupById(int id)
        {
            var advertiseCash = _objAuctionSettingBll.GetById(id);
            if (advertiseCash != null)
            {
                var advertiseCash2 = _objAuctionSettingBll.GetAll()
                    .Select(
                        a => new
                        {
                            a.Id,
                            a.Description,
                            a.CreationDate,
                            a.ModuleID,
                            a.CurrentStage,
                            a.UserId,
                            a.ReviewerId,
                            a.OverrideId,
                            a.AuthoriseId,
                            a.Active,
                            a.RelatorKey,
                            a.IPAddress,
                            a.MacAddress,
                            a.Entry,
                            a.ApprovalEntry,
                            a.StartModuleID,
                            a.BranchId,
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
                    .Where(c => c.Id == id);

                return Ok(advertiseCash2.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });

            }
        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsAuctionSetting")]
        [ResponseType(typeof(TMS_Acct_Setup))]
        public IHttpActionResult Post(TMS_Auction_Settings tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });
            }

            if (!tmsAdvertiseCash.AdvertAmount.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Advert Amount field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.SellingPrice.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Selling Price field cannot be empty!" });
            }
            if (!tmsAdvertiseCash.Bidsstartdate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Bids start date field cannot be empty!" });
            }
            if (tmsAdvertiseCash.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (tmsAdvertiseCash.Description == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //assign default values before inserting
            tmsAdvertiseCash.CreationDate = DateTime.Now;

            try
            {
                int s = _objAuctionSettingBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsAuctionSetting/UpdateAuctionSetting/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAuctionSetting(int id, TMS_Auction_Settings tmsAdvertiseCash)
        {
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
                int s = _objAuctionSettingBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsAuctionSetting/DeleteAuctionSetting/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAuctionSetting(int id)
        {
            var contact = _objAuctionSettingBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objAuctionSettingBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _objAuctionSettingBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }
}

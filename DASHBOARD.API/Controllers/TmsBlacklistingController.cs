using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsBlacklistingController : ApiController
    {
        private TmsBlacklistingBll _blacklistingBll;
        public TmsBlacklistingController()
        {
            _blacklistingBll = new TmsBlacklistingBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsBlacklisting")]
        [ResponseType(typeof(TMS_Blacklisting))]
        public IHttpActionResult GetAllBlacklisting()
        {
            var qry = _blacklistingBll.GetAll().OrderBy(e=>e.Entry);
            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsBlacklisting/GetBlacklistingById/{id}")]
        [ResponseType(typeof(TMS_Blacklisting))]
        public IHttpActionResult GetBlacklistingById(int id)
        {

            var contact = _blacklistingBll.GetById(id).OrderBy(e => e.Entry);
            if (contact.Any())
            {
                var qry = _blacklistingBll.GetById(id).OrderBy(e => e.Entry);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsBlacklisting/GetBlacklistingByContext/{sValue}")]
        [ResponseType(typeof(TMS_Blacklisting))]
        public IHttpActionResult GetBlacklistingByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _blacklistingBll.GetAll()
                    .Where(c => c.AccountId.Equals(sValue))
                    .OrderBy(e => e.Entry);
                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsBlacklisting")]
        [ResponseType(typeof(TMS_Blacklisting))]
        public IHttpActionResult Post(TMS_Blacklisting blacklisting)
        {
            if (!blacklisting.AccountId.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Account Id field cannot be empty!" });
            }
            if (!blacklisting.BlacklistingDate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Blacklisting Date field cannot be empty!" });
            }
            if (blacklisting.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (blacklisting.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //TODO: assign default values before inserting
            //blacklisting.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                int c = _blacklistingBll.Insert(blacklisting);
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

        // PUT: api/TmsBlacklisting/UpdateBlacklisting/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsBlacklisting/UpdateBlacklisting/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateBlacklisting(int id, TMS_Blacklisting blacklisting)
        {
            if (!blacklisting.AccountId.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Account Id field cannot be empty!" });
            }
            if (!blacklisting.BlacklistingDate.HasValue)
            {
                return Json(new { Msg = "0", Reason = "Blacklisting Date field cannot be empty!" });
            }
            if (blacklisting.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (blacklisting.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //TODO: assign default values before inserting
            //blacklisting.CreationDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != blacklisting.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _blacklistingBll.Update(blacklisting);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteBlacklistingExists(id))
                {
                    //return NotFound();
                    return Json(new { Msg = "0", Reason = "Exception!" });
                }
                else
                {
                    throw;
                }
            }
        }


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("DELETE")]
        [Route("api/TmsBlacklisting/DeleteBlacklisting/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBlacklisting(int id)
        {
            var contact = _blacklistingBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _blacklistingBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteBlacklistingExists(int id)
        {
            return _blacklistingBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }

    

        
}

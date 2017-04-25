using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.WebPages;
using PillarSalt.BLL;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineBagDetachmentsController : ApiController
    {
        private TmsMachineBagDetachmentsBll _bdBll;
        public TmsMachineBagDetachmentsController()
        {
            _bdBll = new TmsMachineBagDetachmentsBll();
        }
        //GET: api/TmsMachineBagDetachments
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBagDetachments")]
        [ResponseType(typeof(TMS_MachineBagDetachment))]
        public IHttpActionResult GetAllBank()
        {
            var qry = _bdBll.GetAll().OrderBy(e => e.Entry);
            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBagDetachments/GetMachineBagDetachmentsById/{id}")]
        [ResponseType(typeof(TMS_MachineBagDetachment))]
        public IHttpActionResult GetBankById(int id)
        {
            var contact = _bdBll.GetById(id);
            if (contact != null)
            {
                return Ok(contact.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });
            }

        }

        //GET: api/TmsMachineBagDetachments/GetBankByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBagDetachments/GetMachineBagDetachmentsByContext/{sValue}")]
        [ResponseType(typeof(TMS_MachineBagDetachment))]
        public IHttpActionResult GetBankByContext(string sValue)
        {
            if (!sValue.IsEmpty())
            {
                var qry = _bdBll.GetAll().Where(c => c.MachineBagId.Equals(sValue));
                return Ok(qry.ToList());
            }

            return Json(new { Msg = "0", Reason = "Empty result or search value!" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineBagDetachments")]
        [ResponseType(typeof(TMS_MachineBagDetachment))]
        public IHttpActionResult Post(TMS_MachineBagDetachment mbd)
        {
            if (ModelState.IsValid)
            {
                int c = _bdBll.Insert(mbd);
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
        [Route("api/TmsMachineBagDetachments/UpdateBank")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateBank(int id, TMS_MachineBagDetachment mdb)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != mdb.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _bdBll.Update(mdb);
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
        [Route("api/TmsMachineBagDetachments/DeleteBank/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _bdBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _bdBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool BankMappingExists(int id)
        {
            return _bdBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

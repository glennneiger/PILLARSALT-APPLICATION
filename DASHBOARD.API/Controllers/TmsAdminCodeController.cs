using System;
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
    public class TmsAdminCodeController : ApiController
    {
        private TmsAdminCodeBll _adminCodeBll;
        public TmsAdminCodeController()
        {
            _adminCodeBll = new TmsAdminCodeBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAdminCode")]
        [ResponseType(typeof(TMS_AdminCode))]
        public IHttpActionResult GetAllAdminCode()
        {
            var qry = _adminCodeBll.GetAll();
            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsAdminCode/GetAdminCodeById/{id}")]
        [ResponseType(typeof(TMS_AdminCode))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetAdminCodeById(int id)
        {

            var contact = _adminCodeBll.GetAll().Where(i => i.Id.Equals(id));
            if (contact.Any())
            {
                var qry = _adminCodeBll.GetAll().Where(i => i.Id.Equals(id)).ToList();
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        //GET: api/TmsAdminCode/GetAdminCodeByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAdminCode/GetAdminCodeByContext/{sValue}")]
        [ResponseType(typeof(TMS_AdminCode))]
        public IHttpActionResult GetAdminCodeByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _adminCodeBll.GetAll()
                .Where(c => c.AdminCodeName
                .Contains(sValue))
                .OrderBy(c => c.Entry);
                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsAdminCode/")]
        [ResponseType(typeof(TMS_AdminCode))]
        public IHttpActionResult Post(TMS_AdminCode adminCode)
        {
            if (adminCode.AdminCodeName == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "AdminCode Name field cannot be empty!" });
            }
            if (adminCode.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (adminCode.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            if (ModelState.IsValid)
            {
                int c = _adminCodeBll.Insert(adminCode);
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


        // PUT: api/TmsAdminCode/UpdateAdminCode/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsAdminCode/UpdateAdminCode/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAdminCode(int id, TMS_AdminCode adminCode)
        {
            if (adminCode.AdminCodeName == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "AdminCode Name field cannot be empty!" });
            }
            if (adminCode.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (adminCode.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != adminCode.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _adminCodeBll.Update(adminCode);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteAdminCodeExists(id))
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
        [Route("api/TmsAdminCode/DeleteAdminCode/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAdminCode(int id)
        {
            var contact = _adminCodeBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _adminCodeBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteAdminCodeExists(int id)
        {
            return _adminCodeBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }

    

    
}


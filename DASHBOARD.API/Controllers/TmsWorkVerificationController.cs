using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsWorkVerificationController : ApiController
    {
        private TmsWorkVerificationBll _workVerificationBll;
        public TmsWorkVerificationController()
        {
            _workVerificationBll = new TmsWorkVerificationBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsWorkVerification")]
        [ResponseType(typeof(TMS_WorkVerification))]
        public IHttpActionResult GetAllWorkVerification()
        {
            var qry = _workVerificationBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsWorkVerification/GetWorkVerificationById/{id}")]
        [ResponseType(typeof(TMS_WorkVerification))]
        public IHttpActionResult GetWorkVerificationById(int id)
        {

            var contact = _workVerificationBll.GetById(id);
            if (contact.Any())
            {
                var qry = _workVerificationBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsWorkVerification/GetWorkVerificationByContext/{sValue}")]
        [ResponseType(typeof(TMS_WorkVerification))]
        public IHttpActionResult GetWorkVerificationByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _workVerificationBll.GetAll().Where(c => c.WorkVerificationName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsWorkVerification")]
        [ResponseType(typeof(TMS_WorkVerification))]
        public IHttpActionResult Post(TMS_WorkVerification workVerification)
        {
            if (workVerification.WorkVerificationName == String.Empty)
            {
                return Json(new { Msg = "0", Reason= "Verification Name field cannot be empty!" });
            }
            if (workVerification.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (workVerification.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }



            if (ModelState.IsValid)
            {
                int c = _workVerificationBll.Insert(workVerification);
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

        // PUT: api/TmsWorkVerification/UpdateWorkVerification/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsWorkVerification/UpdateWorkVerification/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateWorkVerification(int id, TMS_WorkVerification workVerification)
        {
            if (workVerification.WorkVerificationName == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Verification Name field cannot be empty!" });
            }
            if (workVerification.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (workVerification.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != workVerification.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _workVerificationBll.Update(workVerification);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteWorkVerificationExists(id))
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
        [Route("api/TmsWorkVerification/DeleteWorkVerification/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteWorkVerification(int id)
        {
            var contact = _workVerificationBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _workVerificationBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteWorkVerificationExists(int id)
        {
            return _workVerificationBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }




}

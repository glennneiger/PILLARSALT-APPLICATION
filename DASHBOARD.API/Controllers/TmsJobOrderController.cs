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
    public class TmsJobOrderController : ApiController
    {
        private TmsJobOrderBll _jobOrderBll;
        public TmsJobOrderController()
        {
            _jobOrderBll = new TmsJobOrderBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsJobOrder")]
        [ResponseType(typeof(TMS_JobOrder))]
        public IHttpActionResult GetAllJobOrder()
        {
            var qry = _jobOrderBll.GetAll()
                .Select(j => new { j.Id, j.Active, j.Entry, j.CreationDate, j.CurrentStage, j.JobOrderName, j.Notes })
                .OrderBy(c => c.Entry);

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsJobOrder/GetJobOrderById/{id}")]
        [ResponseType(typeof(TMS_JobOrder))]
        public IHttpActionResult GetJobOrderById(int id)
        {

            var contact = _jobOrderBll.GetById(id);
            if (contact.Any())
            {
                var qry = _jobOrderBll.GetById(id)
                     .Select(j => new { j.Id, j.Active, j.Entry, j.CreationDate, j.CurrentStage, j.JobOrderName, j.Notes })
                .OrderBy(c => c.Entry);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsJobOrder/GetJobOrderByContext/{sValue}")]
        [ResponseType(typeof(TMS_JobOrder))]
        public IHttpActionResult GetJobOrderByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _jobOrderBll.GetAll().Where(c => c.JobOrderName.Contains(sValue)).Select(j => new { j.Id, j.Active, j.Entry, j.CreationDate, j.CurrentStage, j.JobOrderName, j.Notes })
                .OrderBy(c => c.Entry);
                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsJobOrder")]
        [ResponseType(typeof(TMS_JobOrder))]
        public IHttpActionResult Post(TMS_JobOrder jobOrder)
        {
            if (ModelState.IsValid)
            {
                int c = _jobOrderBll.Insert(jobOrder);
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

        // PUT: api/TmsJobOrder/UpdateJobOrder/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsJobOrder/UpdateJobOrder/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateJobOrder(int id, TMS_JobOrder jobOrder)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != jobOrder.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _jobOrderBll.Update(jobOrder);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteJobOrderExists(id))
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
        [Route("api/TmsJobOrder/DeleteJobOrder/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteJobOrder(int id)
        {
            var contact = _jobOrderBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _jobOrderBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteJobOrderExists(int id)
        {
            return _jobOrderBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }




}

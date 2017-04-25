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
    public class TmsQueryPaymentController : ApiController
    {
        private TmsQueryPaymentBll _queryPaymentBll;
        public TmsQueryPaymentController()
        {
            _queryPaymentBll = new TmsQueryPaymentBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsQueryPayment")]
        [ResponseType(typeof(TMS_QueryPayment))]
        public IHttpActionResult GetAllQueryPayment()
        {
            var qry = _queryPaymentBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsQueryPayment/GetQueryPaymentById/{id}")]
        [ResponseType(typeof(TMS_QueryPayment))]
        public IHttpActionResult GetQueryPaymentById(int id)
        {

            var contact = _queryPaymentBll.GetById(id);
            if (contact.Any())
            {
                var qry = _queryPaymentBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });
            }
        }

        [AcceptVerbs("GET")]
        [Route("api/TmsQueryPayment/GetQueryPaymentByContext/{sValue}")]
        [ResponseType(typeof(TMS_QueryPayment))]
        public IHttpActionResult GetQueryPaymentByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _queryPaymentBll.GetAll().Where(c => c.QueryName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsQueryPayment")]
        [ResponseType(typeof(TMS_QueryPayment))]
        public IHttpActionResult Post(TMS_QueryPayment queryPayment)
        {
            if (ModelState.IsValid)
            {
                int c = _queryPaymentBll.Insert(queryPayment);
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

        // PUT: api/TmsQueryPayment/UpdateQueryPayment/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsQueryPayment/UpdateQueryPayment/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateQueryPayment(int id, TMS_QueryPayment queryPayment)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != queryPayment.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _queryPaymentBll.Update(queryPayment);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteQueryPaymentExists(id))
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
        [Route("api/TmsQueryPayment/DeleteQueryPayment/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteQueryPayment(int id)
        {
            var contact = _queryPaymentBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _queryPaymentBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteQueryPaymentExists(int id)
        {
            return _queryPaymentBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

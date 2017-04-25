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
    public class TmsPaymentScheduleController : ApiController
    {
        private TmsPaymentScheduleBll _paymentScheduleBll;
        public TmsPaymentScheduleController()
        {
            _paymentScheduleBll = new TmsPaymentScheduleBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsPaymentSchedule")]
        [ResponseType(typeof(TMS_PaymentSchedule))]
        public IHttpActionResult GetAllPaymentSchedule()
        {
            var qry = _paymentScheduleBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsPaymentSchedule/GetPaymentScheduleById/{id}")]
        [ResponseType(typeof(TMS_PaymentSchedule))]
        public IHttpActionResult GetPaymentScheduleById(int id)
        {

            var contact = _paymentScheduleBll.GetById(id);
            if (contact.Any())
            {
                var qry = _paymentScheduleBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsPaymentSchedule/GetPaymentScheduleByContext/{sValue}")]
        [ResponseType(typeof(TMS_PaymentSchedule))]
        public IHttpActionResult GetPaymentScheduleByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _paymentScheduleBll.GetAll().Where(c => c.ScheduleName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsPaymentSchedule")]
        [ResponseType(typeof(TMS_PaymentSchedule))]
        public IHttpActionResult Post(TMS_PaymentSchedule paymentSchedule)
        {
            if (ModelState.IsValid)
            {
                int c = _paymentScheduleBll.Insert(paymentSchedule);
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

        // PUT: api/TmsPaymentSchedule/UpdatePaymentSchedule/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsPaymentSchedule/UpdatePaymentSchedule/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdatePaymentSchedule(int id, TMS_PaymentSchedule paymentSchedule)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != paymentSchedule.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _paymentScheduleBll.Update(paymentSchedule);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeletePaymentScheduleExists(id))
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
        [Route("api/TmsPaymentSchedule/DeletePaymentSchedule/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeletePaymentSchedule(int id)
        {
            var contact = _paymentScheduleBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _paymentScheduleBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }
        
        private bool DeletePaymentScheduleExists(int id)
        {
            return _paymentScheduleBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

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
    public class TmsWarrantyStatusController : ApiController
    {
        private TmsWarrantyStatusBll _warrantyStatusBll;
        public TmsWarrantyStatusController()
        {
            _warrantyStatusBll = new TmsWarrantyStatusBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsWarrantyStatus")]
        [ResponseType(typeof(TMS_WarrantyStatus))]
        public IHttpActionResult GetAllWarrantyStatus()
        {
            var qry = _warrantyStatusBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsWarrantyStatus/GetWarrantyStatusById/{id}")]
        [ResponseType(typeof(TMS_WarrantyStatus))]
        public IHttpActionResult GetWarrantyStatusById(int id)
        {

            var contact = _warrantyStatusBll.GetById(id);
            if (contact.Any())
            {
                var qry = _warrantyStatusBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsWarrantyStatus/GetWarrantyStatusByContext/{sValue}")]
        [ResponseType(typeof(TMS_WarrantyStatus))]
        public IHttpActionResult GetWarrantyStatusByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _warrantyStatusBll.GetAll().Where(c => c.Description.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsWarrantyStatus")]
        [ResponseType(typeof(TMS_WarrantyStatus))]
        public IHttpActionResult Post(TMS_WarrantyStatus warrantyStatus)
        {
            if (ModelState.IsValid)
            {
                int c = _warrantyStatusBll.Insert(warrantyStatus);
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

        // PUT: api/TmsWarrantyStatus/UpdateWarrantyStatus/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsWarrantyStatus/UpdateWarrantyStatus/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateWarrantyStatus(int id, TMS_WarrantyStatus warrantyStatus)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != warrantyStatus.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _warrantyStatusBll.Update(warrantyStatus);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteWarrantyStatusExists(id))
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
        [Route("api/TmsWarrantyStatus/DeleteWarrantyStatus/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteWarrantyStatus(int id)
        {
            var contact = _warrantyStatusBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _warrantyStatusBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteWarrantyStatusExists(int id)
        {
            return _warrantyStatusBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

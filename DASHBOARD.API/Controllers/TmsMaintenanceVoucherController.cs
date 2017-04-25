using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMaintenanceVoucherController : ApiController
    {
        private TmsMaintenanceVoucherBll _maintenanceVoucherBll;
        public TmsMaintenanceVoucherController()
        {
            _maintenanceVoucherBll = new TmsMaintenanceVoucherBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMaintenanceVoucher")]
        [ResponseType(typeof(TMS_MaintenanceVoucher))]
        public IHttpActionResult GetAllMaintenanceVoucher()
        {
            var qry = _maintenanceVoucherBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsMaintenanceVoucher/GetMaintenanceVoucherById/{id}")]
        [ResponseType(typeof(TMS_MaintenanceVoucher))]
        public IHttpActionResult GetMaintenanceVoucherById(int id)
        {

            var contact = _maintenanceVoucherBll.GetById(id);
            if (contact.Any())
            {
                var qry = _maintenanceVoucherBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsMaintenanceVoucher/GetMaintenanceVoucherByContext/{sValue}")]
        [ResponseType(typeof(TMS_MaintenanceVoucher))]
        public IHttpActionResult GetMaintenanceVoucherByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _maintenanceVoucherBll.GetAll().Where(c => c.MaintenanceVoucherName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsMaintenanceVoucher")]
        [ResponseType(typeof(TMS_MaintenanceVoucher))]
        public IHttpActionResult Post(TMS_MaintenanceVoucher maintenanceVoucher)
        {
            if (ModelState.IsValid)
            {
                int c = _maintenanceVoucherBll.Insert(maintenanceVoucher);
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

        // PUT: api/TmsMaintenanceVoucher/UpdateMaintenanceVoucher/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsMaintenanceVoucher/UpdateMaintenanceVoucher/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMaintenanceVoucher(int id, TMS_MaintenanceVoucher maintenanceVoucher)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != maintenanceVoucher.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _maintenanceVoucherBll.Update(maintenanceVoucher);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteMaintenanceVoucherExists(id))
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
        [Route("api/TmsMaintenanceVoucher/DeleteMaintenanceVoucher/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteMaintenanceVoucher(int id)
        {
            var contact = _maintenanceVoucherBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _maintenanceVoucherBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteMaintenanceVoucherExists(int id)
        {
            return _maintenanceVoucherBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

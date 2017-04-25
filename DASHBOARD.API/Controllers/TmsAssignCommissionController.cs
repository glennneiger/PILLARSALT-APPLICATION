using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAssignCommissionController : ApiController
    {
        private TmsAssignCommissionBll _assignCommissionBll;
        public TmsAssignCommissionController()
        {
            _assignCommissionBll = new TmsAssignCommissionBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignCommission")]
        [ResponseType(typeof(TMS_Assign_Commission))]
        public IHttpActionResult GetAllAdvertBilling()
        {
            var contact = _assignCommissionBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.CustomersName,
                            a.Notes,
                            a.Entry
                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.Entry);

            return Ok(contact.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignCommission/GetAssignCommissionById/{id}")]
        [ResponseType(typeof(TMS_Assign_Commission))]
        public IHttpActionResult GetAssignCommissionById(int id)
        {
            var contact = _assignCommissionBll.GetById(id);
            if (contact != null)
            {
                var contact2 = _assignCommissionBll.GetAll()
                    .Select(
                        a => new
                        {
                            a.Id,
                            a.CustomersName,
                            a.Notes,
                            a.Entry
                        }
                    )
                    .Where(c => c.Id == id);

                return Ok(contact2);
            }
            else
            {
                return Json(new { Msg = "0" });

            }

        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignCommission/GetAssignCommissionByContext/{sValue}")]
        [ResponseType(typeof(TMS_Assign_Commission))]
        public IHttpActionResult GetAssignCommissionByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _assignCommissionBll.GetAll().Where(c => c.CustomersName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        a =>
                            new
                            {
                                a.Id,
                                a.CustomersName,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }
            return Json(new { Msg = "0" });
        }


        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignCommission")]
        [ResponseType(typeof(TMS_Assign_Commission))]
        public IHttpActionResult Post(TMS_Assign_Commission tmsAdvertBilling)
        {
            if (ModelState.IsValid)
            {
                int c = _assignCommissionBll.Insert(tmsAdvertBilling);
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


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignCommission/UpdateAssignCommission/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAssignCommission(int id, TMS_Assign_Commission advertBilling)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != advertBilling.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _assignCommissionBll.Update(advertBilling);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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


        // PUT: api/TmsAssignCommission/DeleteAdvertBilling/{id}
        [AcceptVerbs("DELETE")]
        [Route("api/TmsAssignCommission/DeleteAssignCommission/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAssignCommission(int id)
        {
            var contact = _assignCommissionBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _assignCommissionBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool ContactExists(int id)
        {
            return _assignCommissionBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    
}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsDenominationController : ApiController
    {
        private TmsDenominationBll _denominationBll;

        public TmsDenominationController()
        {
            _denominationBll = new TmsDenominationBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/TmsDenomination")]
        [ResponseType(typeof(TMS_Denomination))]
        public IHttpActionResult GetAllDenomination()
        {
            var qry = from d in _denominationBll.GetAll()
                      select new { d.Id, d.Description, d.Active };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetDenominationMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsDenomination/GetDenominationById/{id}")]
        [ResponseType(typeof(TMS_Denomination))]
        public IHttpActionResult GetDenominationById(int id)
        {

            var contact = _denominationBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _denominationBll.GetById(id)
                          select new { d.Id, d.Description, d.Active };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/TmsDenomination/GetDenominationByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsDenomination/GetDenominationByContext/{sValue}")]
        [ResponseType(typeof(TMS_Denomination))]
        public IHttpActionResult GetDenominationByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _denominationBll.GetAll().Where(c => c.Description.Contains(sValue))
                          select new { d.Id, d.Description, d.Active };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsDenomination")]
        [ResponseType(typeof(TMS_Denomination))]
        public IHttpActionResult Post(TMS_Denomination accountsDenominationDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _denominationBll.Insert(accountsDenominationDetails);
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


        // PUT: api/AccAccountsDenominationDetails/UpdateAccountsDenominationDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsDenomination/UpdateDenomination")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateDenomination(int id, TMS_Denomination accountsDenominationDetails)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != accountsDenominationDetails.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _denominationBll.Update(accountsDenominationDetails);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenominationMappingExists(id))
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
        [Route("api/TmsDenomination/DeleteDenomination/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _denominationBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _denominationBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool DenominationMappingExists(int id)
        {
            return _denominationBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

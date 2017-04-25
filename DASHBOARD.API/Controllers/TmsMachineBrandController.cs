using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineBrandController : ApiController
    {
        private TmsMachineBrandBll _objMachineBrandBll;
        public TmsMachineBrandController()
        {
            _objMachineBrandBll = new TmsMachineBrandBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBrand")]
        [ResponseType(typeof(TMS_Machine_Brand))]
        public IHttpActionResult GetAllMachineBrand()
        {
            var doc = _objMachineBrandBll.GetAll()
                .OrderBy(d => d.Entry).ThenByDescending(d => d.Entry);

            return Ok(doc.ToList());
        }

        //GET: api/TmsMachineBrand/GetMachineBrandByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBrand/GetMachineBrandByContext/{sValue}")]
        [ResponseType(typeof(TMS_Machine_Brand))]
        public IHttpActionResult GetMachineBrandByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objMachineBrandBll.GetAll()
                    .Where(c => c.Description.Contains(sValue))
                    .OrderBy(e=>e.Entry).ToList();
                
                return Ok(context.ToList());
            }

            return Ok(new { Msg = "0" });
        }

        //GET: api/TmsMachineBrand/GetMachineBrandById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBrand/GetMachineBrandById/{id}")]
        [ResponseType(typeof(TMS_Machine_Brand))]
        public IHttpActionResult GetMachineBrandById(int id)
        {
            var disposal = _objMachineBrandBll.GetAll().Where(c => c.Id.Equals(id));
            return Ok(disposal.ToList());
        }

        [AcceptVerbs("POST")]
        [Route("api/TmsMachineBrand/InsertMachineBrand")]
        [ResponseType(typeof(TMS_Machine_Brand))]
        public IHttpActionResult InsertMachineBrand(TMS_Machine_Brand tmsMachineBrand)
        {
            if (tmsMachineBrand == null)
            {
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineBrandBll.Insert(tmsMachineBrand);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0" });
            }
        }


        [AcceptVerbs("POST")]
        [Route("api/TmsMachineBrand/UpdateMachineBrand")]
        [ResponseType(typeof(TMS_Machine_Brand))]
        public IHttpActionResult UpdateMachineBrand(int id, TMS_Machine_Brand tmsMachineBrand)
        {
            if (tmsMachineBrand == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsMachineBrand.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineBrandBll.Update(tmsMachineBrand);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsMobilityExists(id))
                {
                    //return NotFound();
                    return Ok(new { Msg = "0", Reason = "No row affected!" });
                }
                else
                {
                    throw;
                }
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("api/TmsMachineBrand/InsertMachineBrand")]
        [ResponseType(typeof(TMS_Machine_Brand))]
        public IHttpActionResult DeleteMachineBrand(int id)
        {
            var disburse = _objMachineBrandBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objMachineBrandBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsMobilityExists(int id)
        {
            return _objMachineBrandBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

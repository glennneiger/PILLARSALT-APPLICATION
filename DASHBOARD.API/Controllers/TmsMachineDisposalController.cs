using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineDisposalController : ApiController
    {
        private TmsMachineDisposalBll _objMachineDisposalBll;

        public TmsMachineDisposalController()
        {
            _objMachineDisposalBll = new TmsMachineDisposalBll();
        }

        //GET: api/TmsMachineDisposal
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineDisposal")]
        [ResponseType(typeof(TMS_Machine_Disposal))]
        public IHttpActionResult GetAllMachineDisposal()
        {
            var disposal = _objMachineDisposalBll.GetAll()
                .OrderBy(d => d.Entry);
            return Ok(disposal.ToList());
        }

        //GET: api/TmsMachineDisposal/GetMachineDisposalByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineDisposal/GetMachineDisposalByContext/{sValue}")]
        [ResponseType(typeof(TMS_Machine_Disposal))]
        public IHttpActionResult GetMachineDisposalByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objMachineDisposalBll.GetAll()
                    .Where(c => c.Description.Contains(sValue))
                    .OrderBy(c => c.Description).ToList();
                return Ok(context.ToList());
            }

            return Ok(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDisposal/GetMachineDisposalById/{id}")]
        [ResponseType(typeof(TMS_Machine_Disposal))]
        public IHttpActionResult GetMachineDisposalById(int id)
        {
            var disposal = _objMachineDisposalBll.GetAll().Where(c => c.Id.Equals(id));
            return Ok(disposal.ToList());
        }

        //GET: api/TmsMachineDisposal/InsertMachineDisposal
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDisposal/InsertMachineDisposal")]
        [ResponseType(typeof(TMS_Machine_Disposal))]
        public IHttpActionResult InsertMachineDisposal(TMS_Machine_Disposal tmsMachineDisposal)
        {
            if (tmsMachineDisposal == null)
            {
                return Ok(new { Msg = "0" });
            }
            try
            {
                int s = _objMachineDisposalBll.Insert(tmsMachineDisposal);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0", Reason = "No row affected!" });
            }
        }

        //GET: api/TmsMachineDisposal/UpdateMachineDisposal
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDisposal/UpdateMachineDisposal")]
        [ResponseType(typeof(TMS_Machine_Disposal))]
        public IHttpActionResult UpdateMachineDisposal(int id, TMS_Machine_Disposal tmsMachineDisposal)
        {
            if (tmsMachineDisposal == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsMachineDisposal.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineDisposalBll.Update(tmsMachineDisposal);
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

        //GET: api/TmsMachineDisposal/DeleteMachineDisposal
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDisposal/DeleteMachineDisposal")]
        [ResponseType(typeof(TMS_Machine_Disposal))]
        public IHttpActionResult DeleteMachineDisposal(int id)
        {
            var disburse = _objMachineDisposalBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objMachineDisposalBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsMobilityExists(int id)
        {
            return _objMachineDisposalBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMobilityController : ApiController
    {
        private TmsMobilityBll _objTmsMobilityBll;
        public TmsMobilityController()
        {
            _objTmsMobilityBll = new TmsMobilityBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMobility")]
        [ResponseType(typeof(TMS_Mobility))]
        public IHttpActionResult GetAllMobility()
        {
            var mobility = _objTmsMobilityBll.GetAll()
                .Select(
                    m =>
                        new
                        {
                            m.Id,
                            m.Description,
                            m.ModuleID,
                            m.CurrentStage,
                            m.UserId,
                            m.ReviewerId,
                            m.OverrideId,
                            m.AuthoriseId,
                            m.Active,
                            m.RelatorKey,
                            m.IPAddress,
                            m.MacAddress,
                            m.Entry,
                            m.ApprovalEntry,
                            m.CreationDate,
                            m.StartModuleID,
                            m.BranchId,
                            m.Notes,
                            m.Revision,
                            m.Token,
                            m.EditReason,
                            m.TokenOwner,
                            m.TokenManifestId,
                            m.DeclineId,
                            m.ReviewEntry,
                            m.DeclineReason,
                            m.ApprovalComment,
                            m.ReviewerComment,
                            m.UpdateLocker
                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.Entry);

            return Ok(mobility.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsMobility/GetMobilityByContext/{sValue}")]
        [ResponseType(typeof(TMS_Mobility))]
        public IHttpActionResult GetMobilityByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objTmsMobilityBll.GetAll().Where(c => c.Description.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        c =>
                            new
                            {
                                c.Id,
                                c.Description,
                                c.Active
                            }).OrderBy(c => c.Description).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }
            return Ok(new { Msg = "0" });
        }


        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMobility/GetMobilityById/{id}")]
        [ResponseType(typeof(TMS_Mobility))]
        public IHttpActionResult GetMobilityById(int id)
        {
            var disburse = _objTmsMobilityBll.GetAll().Where(c => c.Id.Equals(id));
            return Ok(disburse.ToList());
        }

        [AcceptVerbs("POST")]
        [Route("api/TmsMobility")]
        [ResponseType(typeof(TMS_Mobility))]
        public IHttpActionResult Post(TMS_Mobility tmsMobility)
        {
            if (tmsMobility == null)
            {
                return Ok(new { Msg = "0" });
            }


            try
            {
                int s = _objTmsMobilityBll.Insert(tmsMobility);
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

        [AcceptVerbs("POST")]
        [Route("api/TmsMobility/UpdateMobility")]
        [ResponseType(typeof(TMS_Mobility))]
        public IHttpActionResult UpdateMobility(int id, TMS_Mobility tmsMobility)
        {
            if (tmsMobility == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsMobility.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objTmsMobilityBll.Update(tmsMobility);
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
        [Route("api/TmsMobility/DeleteMobility")]
        [ResponseType(typeof(TMS_Mobility))]
        public IHttpActionResult DeleteMobility(int id)
        {
            var disburse = _objTmsMobilityBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objTmsMobilityBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsMobilityExists(int id)
        {
            return _objTmsMobilityBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

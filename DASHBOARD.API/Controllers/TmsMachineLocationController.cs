using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineLocationController : ApiController
    {
        private TmsMachineLocationBll _objMachineLocationBll;
        public TmsMachineLocationController()
        {
            _objMachineLocationBll = new TmsMachineLocationBll();
        }


        //GET: api/TmsMachineDocument
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineLocation")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult GetAllMachineLocation()
        {
            var loc = _objMachineLocationBll.GetAll()
                .Select(
                    d =>
                        new
                        {
                            d.Id,
                            d.Description,
                            d.DeptId,
                            d.Building,
                            d.Floor,
                            d.ModuleID,
                            d.CurrentStage,
                            d.UserId,
                            d.ReviewerId,
                            d.OverrideId,
                            d.AuthoriseId,
                            d.Active,
                            d.RelatorKey,
                            d.IPAddress,
                            d.MacAddress,
                            d.Entry,
                            d.ApprovalEntry,
                            d.CreationDate,
                            d.StartModuleID,
                            d.BranchId,
                            d.Notes,
                            d.Revision,
                            d.Token,
                            d.EditReason,
                            d.TokenOwner,
                            d.TokenManifestId,
                            d.DeclineId,
                            d.ReviewEntry,
                            d.DeclineReason,
                            d.ApprovalComment,
                            d.ReviewerComment,
                            d.UpdateLocker

                        }).OrderBy(d => d.Entry).ThenByDescending(d => d.Entry);

            return Ok(loc.ToList());
        }

        //GET: api/TmsModels/GetMachineLocationByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsModels/GetMachineLocationByContext/{sValue}")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult GetMachineLocationByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objMachineLocationBll.GetAll().Where(c => c.Description.Contains(sValue)).ToList();
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

        //GET: api/TmsMachineLocation/GetMachineLocationById/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineLocation/GetMachineLocationById/{id}")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult GetMachineLocationById(int id)
        {
            var loc = _objMachineLocationBll.GetAll().Where(c => c.Id.Equals(id));
            return Ok(loc.ToList());
        }

        //GET: api/TmsMachineLocation/InsertMachineLocation
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineLocation/InsertMachineLocation")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult InsertMachineLocation(TMS_Machine_Locations tmsMachineLocations)
        {
            if (tmsMachineLocations == null)
            {
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineLocationBll.Insert(tmsMachineLocations);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0", Reason = "Exception!" });
            }
        }

        //GET: api/TmsMachineLocation/InsertMachineLocation
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineLocation/UpdateMachineLocation")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult UpdateMachineLocation(int id, TMS_Machine_Locations tmsMachineLocations)
        {
            if (tmsMachineLocations == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsMachineLocations.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineLocationBll.Update(tmsMachineLocations);
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

        //GET: api/TmsMachineLocation/InsertMachineLocation
        [AcceptVerbs("DELETE")]
        [Route("api/TmsMachineLocation/DeleteMachineLocation")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult DeleteMachineLocation(int id)
        {
            var disburse = _objMachineLocationBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objMachineLocationBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsMobilityExists(int id)
        {
            return _objMachineLocationBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

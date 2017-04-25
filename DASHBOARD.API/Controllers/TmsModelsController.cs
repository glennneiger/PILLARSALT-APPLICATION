using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Services;
using System.Web.Services;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsModelsController : ApiController
    {
        private TmsModelsBll _objTmsModelsBll;
        public TmsModelsController()
        {
            _objTmsModelsBll = new TmsModelsBll();      
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsModels")]
        [ResponseType(typeof(TMS_Models))]
        public IHttpActionResult GetAllModel()
        {
            var model = _objTmsModelsBll.GetAll()
                .Select(
                    m =>
                        new
                        {
                            m.Id,
                            m.Description,
                            m.ModelNo,
                            m.BrandID,
                            m.CategoryId,
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
                        }).OrderBy(c => c.Entry);

            return Ok(model.ToList());  
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsModels/GetContactByContext/{sValue}")]
        [ResponseType(typeof(TMS_Models))]
        public IHttpActionResult GetModelByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objTmsModelsBll.GetAll().Where(c => c.Description.Contains(sValue)).ToList();
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
        [Route("api/TmsModels/GetTModelById/{id}")]
        [ResponseType(typeof(TMS_Models))]
        public IHttpActionResult GetModelById(int id)
        {
            var model = _objTmsModelsBll.GetById(id);
            if (model != null)
            {
                var model2 = _objTmsModelsBll.GetAll()
                    .Select(
                        m => new
                        {
                            m.Id,
                            m.Description,
                            m.ModelNo,
                            m.BrandID,
                            m.CategoryId,
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
                        }
                    )
                    .Where(c => c.Id == id);

                return Ok(model2.ToList());
            }
            else
            {
                return Ok(new { Msg = "0" });

            }
        }

        //GET: api/TmsModels
        [AcceptVerbs("POST")]
        [Route("api/TmsModels")]
        [ResponseType(typeof(TMS_Models))]
        public IHttpActionResult Post(TMS_Models tmsModels)
        {
            if (tmsModels == null)
            {
                return Ok(new { Msg = "0" });

            }

            try
            {
                int s = _objTmsModelsBll.Insert(tmsModels);
                if (s == 1)
                {
                    return Ok(new { Msg = "1" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0", Reason = "No row affected!" });
            }
        }

        //POST: api/TmsModels/UpdateModel
        [AcceptVerbs("POST")]
        [Route("api/TmsModels/UpdateModel")]
        [ResponseType(typeof(TMS_Models))]
        public IHttpActionResult UpdateModel(int id, TMS_Models tmsModels)
        {
            if (tmsModels == null)
            {
                return Ok(new { Msg = "0" });

            }

            if (id != tmsModels.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objTmsModelsBll.Update(tmsModels);
                if (s == 1)
                {
                    return Ok(new { Msg = "1" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrmContactExists(id))
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


        //POST: api/TmsModels/UpdateModel
        [AcceptVerbs("POST")]
        [Route("api/TmsModels/DeleteContact")]
        [ResponseType(typeof(TMS_Models))]
        public IHttpActionResult DeleteContact(int id)
        {
            var contact = _objTmsModelsBll.GetById(id);
            if (contact == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objTmsModelsBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }


        private bool CrmContactExists(int id)
        {
            return _objTmsModelsBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsSectorSettingsController : ApiController
    {
        private TmsSectorSettingsBll _sectorSettingsBll;
        public TmsSectorSettingsController()
        {
            _sectorSettingsBll = new TmsSectorSettingsBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsSectorSettings")]
        [ResponseType(typeof(TMS_SectorSettings))]
        public IHttpActionResult GetAllSectorSettings()
        {
            var qry = _sectorSettingsBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsSectorSettings/GetSectorSettingsById/{id}")]
        [ResponseType(typeof(TMS_SectorSettings))]
        public IHttpActionResult GetSectorSettingsById(int id)
        {

            var contact = _sectorSettingsBll.GetById(id);
            if (contact.Any())
            {
                var qry = _sectorSettingsBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsSectorSettings/GetSectorSettingsByContext/{sValue}")]
        [ResponseType(typeof(TMS_SectorSettings))]
        public IHttpActionResult GetSectorSettingsByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _sectorSettingsBll.GetAll().Where(c => c.Sector_Name.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsSectorSettings")]
        [ResponseType(typeof(TMS_SectorSettings))]
        public IHttpActionResult Post(TMS_SectorSettings sectorSettings)
        {
            if (ModelState.IsValid)
            {
                int c = _sectorSettingsBll.Insert(sectorSettings);
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

        // PUT: api/TmsSectorSettings/UpdateSectorSettings/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsSectorSettings/UpdateSectorSettings/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSectorSettings(int id, TMS_SectorSettings sectorSettings)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != sectorSettings.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _sectorSettingsBll.Update(sectorSettings);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteSectorSettingsExists(id))
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
        [Route("api/TmsSectorSettings/DeleteSectorSettings/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteSectorSettings(int id)
        {
            var contact = _sectorSettingsBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _sectorSettingsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteSectorSettingsExists(int id)
        {
            return _sectorSettingsBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

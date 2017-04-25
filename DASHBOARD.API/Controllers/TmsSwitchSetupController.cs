using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsSwitchSetupController : ApiController
    {
        private TmsSwitchSetupBll _switchSetupBll;
        public TmsSwitchSetupController()
        {
            _switchSetupBll = new TmsSwitchSetupBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsSwitchSetup")]
        [ResponseType(typeof(TMS_SwitchSetup))]
        public IHttpActionResult GetAllSwitchSetup()
        {
            var qry = _switchSetupBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsSwitchSetup/GetSwitchSetupById/{id}")]
        [ResponseType(typeof(TMS_SwitchSetup))]
        public IHttpActionResult GetSwitchSetupById(int id)
        {

            var contact = _switchSetupBll.GetById(id);
            if (contact.Any())
            {
                var qry = _switchSetupBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsSwitchSetup/GetSwitchSetupByContext/{sValue}")]
        [ResponseType(typeof(TMS_SwitchSetup))]
        public IHttpActionResult GetSwitchSetupByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _switchSetupBll.GetAll().Where(c => c.SwitchName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsSwitchSetup")]
        [ResponseType(typeof(TMS_SwitchSetup))]
        public IHttpActionResult Post(TMS_SwitchSetup switchSetup)
        {
            if (ModelState.IsValid)
            {
                int c = _switchSetupBll.Insert(switchSetup);
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

        // PUT: api/TmsSwitchSetup/UpdateSwitchSetup/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsSwitchSetup/UpdateSwitchSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSwitchSetup(int id, TMS_SwitchSetup switchSetup)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != switchSetup.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _switchSetupBll.Update(switchSetup);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteSwitchSetupExists(id))
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
        [Route("api/TmsSwitchSetup/DeleteSwitchSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteSwitchSetup(int id)
        {
            var contact = _switchSetupBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _switchSetupBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteSwitchSetupExists(int id)
        {
            return _switchSetupBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

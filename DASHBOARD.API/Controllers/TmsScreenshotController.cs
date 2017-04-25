using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsScreenshotController : ApiController
    {
        private TmsScreenshotBll _screenshotBll;
        public TmsScreenshotController()
        {
            _screenshotBll = new TmsScreenshotBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsScreenshot")]
        [ResponseType(typeof(TMS_Screenshot))]
        public IHttpActionResult GetAllScreenshot()
        {
            var qry = _screenshotBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsScreenshot/GetScreenshotById/{id}")]
        [ResponseType(typeof(TMS_Screenshot))]
        public IHttpActionResult GetScreenshotById(int id)
        {

            var contact = _screenshotBll.GetById(id);
            if (contact.Any())
            {
                var qry = _screenshotBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });
            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsScreenshot/GetScreenshotByContext/{sValue}")]
        [ResponseType(typeof(TMS_Screenshot))]
        public IHttpActionResult GetScreenshotByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _screenshotBll.GetAll().Where(c => c.ScreenshotName.Contains(sValue));
                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsScreenshot")]
        [ResponseType(typeof(TMS_Screenshot))]
        public IHttpActionResult Post(TMS_Screenshot screenshot)
        {
            if (ModelState.IsValid)
            {
                int c = _screenshotBll.Insert(screenshot);
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

        // PUT: api/TmsScreenshot/UpdateScreenshot/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsScreenshot/UpdateScreenshot/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateScreenshot(int id, TMS_Screenshot screenshot)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != screenshot.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _screenshotBll.Update(screenshot);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteScreenshotExists(id))
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
        [Route("api/TmsScreenshot/DeleteScreenshot/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteScreenshot(int id)
        {
            var contact = _screenshotBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _screenshotBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteScreenshotExists(int id)
        {
            return _screenshotBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

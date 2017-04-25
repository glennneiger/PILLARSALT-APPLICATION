using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsSendCommandController : ApiController
    {
        private TmsSendCommandBll _sendCommandBll;
        public TmsSendCommandController()
        {
            _sendCommandBll = new TmsSendCommandBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsSendCommand")]
        [ResponseType(typeof(TMS_SendCommand))]
        public IHttpActionResult GetAllSendCommand()
        {
            var qry = _sendCommandBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsSendCommand/GetSendCommandById/{id}")]
        [ResponseType(typeof(TMS_SendCommand))]
        public IHttpActionResult GetSendCommandById(int id)
        {

            var contact = _sendCommandBll.GetById(id);
            if (contact.Any())
            {
                var qry = _sendCommandBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsSendCommand/GetSendCommandByContext/{sValue}")]
        [ResponseType(typeof(TMS_SendCommand))]
        public IHttpActionResult GetSendCommandByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _sendCommandBll.GetAll().Where(c => c.CommandName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsSendCommand")]
        [ResponseType(typeof(TMS_SendCommand))]
        public IHttpActionResult Post(TMS_SendCommand sendCommand)
        {
            if (ModelState.IsValid)
            {
                int c = _sendCommandBll.Insert(sendCommand);
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

        // PUT: api/TmsSendCommand/UpdateSendCommand/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsSendCommand/UpdateSendCommand/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSendCommand(int id, TMS_SendCommand sendCommand)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != sendCommand.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _sendCommandBll.Update(sendCommand);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteSendCommandExists(id))
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
        [Route("api/TmsSendCommand/DeleteSendCommand/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteSendCommand(int id)
        {
            var contact = _sendCommandBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _sendCommandBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteSendCommandExists(int id)
        {
            return _sendCommandBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    


}

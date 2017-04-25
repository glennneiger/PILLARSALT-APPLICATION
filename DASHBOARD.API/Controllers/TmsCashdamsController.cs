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
    public class TmsCashdamsController : ApiController
    {
        private TmsCashdamsBll _cashdamsBll;
        public TmsCashdamsController()
        {
            _cashdamsBll = new TmsCashdamsBll();
        }


        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsCashdams")]
        [ResponseType(typeof(TMS_Cashdams))]
        public IHttpActionResult GetAllCashdams()
        {
            var qry = _cashdamsBll.GetAll().OrderBy(c => c.Entry);
            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsCashdams/GetCashdamsById/{id}")]
        [ResponseType(typeof(TMS_Cashdams))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetCashdamsById(int id)
        {

            var contact = _cashdamsBll.GetAll().Where(i => i.Id.Equals(id)).ToList();
            if (contact.Any())
            {
                return Ok(contact.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        //GET: api/TmsCashdams/GetCashdamsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsCashdams/GetCashdamsByContext/{sValue}")]
        [ResponseType(typeof(TMS_Cashdams))]
        public IHttpActionResult GetCashdamsByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _cashdamsBll.GetAll().Where(c => c.Cash_Destination.Contains(sValue) || c.Cash_Location.Contains(sValue)).OrderBy(c => c.Entry).ToList();

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsCashdams")]
        [ResponseType(typeof(TMS_Cashdams))]
        public IHttpActionResult Post(TMS_Cashdams cashdams)
        {
            if (ModelState.IsValid)
            {
                int c = _cashdamsBll.Insert(cashdams);
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


        // PUT: api/TmsCashdams/UpdateCashdams/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsCashdams/UpdateCashdams/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCashdams(int id, TMS_Cashdams cashdams)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != cashdams.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _cashdamsBll.Update(cashdams);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteCashdamsExists(id))
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
        [Route("api/TmsCashdams/DeleteCashdams/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCashdams(int id)
        {
            var contact = _cashdamsBll.GetAll().Where(i => i.Id.Equals(id));
            if (contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _cashdamsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteCashdamsExists(int id)
        {
            return _cashdamsBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }

    

    
}

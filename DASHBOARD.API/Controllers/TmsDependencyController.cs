using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsDependencyController : ApiController
    {

        private TmsDependencyBll _dependencyBll;
        public TmsDependencyController()
        {
            _dependencyBll = new TmsDependencyBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsDependency")]
        [ResponseType(typeof(TMS_Dependency))]
        public IHttpActionResult GetAllDependency()
        {
            var qry = _dependencyBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsDependency/GetDependencyById/{id}")]
        [ResponseType(typeof(TMS_Dependency))]
        public IHttpActionResult GetDependencyById(int id)
        {

            var contact = _dependencyBll.GetById(id);
            if (contact.Any())
            {
                var qry = _dependencyBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsDependency/GetDependencyByContext/{sValue}")]
        [ResponseType(typeof(TMS_Dependency))]
        public IHttpActionResult GetDependencyByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _dependencyBll.GetAll().Where(c => c.DependencyName.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsDependency")]
        [ResponseType(typeof(TMS_Dependency))]
        public IHttpActionResult Post(TMS_Dependency dependency)
        {
            if (ModelState.IsValid)
            {
                int c = _dependencyBll.Insert(dependency);
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

        // PUT: api/TmsDependency/UpdateDependency/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsDependency/UpdateDependency/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateDependency(int id, TMS_Dependency dependency)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != dependency.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _dependencyBll.Update(dependency);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteDependencyExists(id))
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
        [Route("api/TmsDependency/DeleteDependency/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteDependency(int id)
        {
            var contact = _dependencyBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _dependencyBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteDependencyExists(int id)
        {
            return _dependencyBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

}

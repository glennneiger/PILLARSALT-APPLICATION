using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAssignPackageController : ApiController
    {
        private TmsAssignPackageBll _assignPackageBll;
        public TmsAssignPackageController()
        {
            _assignPackageBll = new TmsAssignPackageBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignPackage")]
        [ResponseType(typeof(TMS_AssignPackage))]
        public IHttpActionResult GetAllAssignPackage()
        {
            var mp = _assignPackageBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.PackageCategory,
                            a.PackageName,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsAssignPackage/GetAssignPackageByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignPackage/GetAssignPackageByContext/{sValue}")]
        [ResponseType(typeof(TMS_AssignPackage))]
        public IHttpActionResult GetAssignPackageByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _assignPackageBll.GetAll().Where(c => c.PackageName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.PackageCategory,
                                a.PackageName,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsAssignPackage/GeAssignPackageById/{id}")]
        [ResponseType(typeof(TMS_AssignPackage))]
        public IHttpActionResult GetAssignPackageById(int id)
        {
            if (id != 0)
            {
                var mp = _assignPackageBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.PackageCategory,
                        a.PackageName,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignPackage")]
        [ResponseType(typeof(TMS_AssignPackage))]
        public IHttpActionResult Post(TMS_AssignPackage tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _assignPackageBll.Insert(tmsAdvertiseCash);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });

                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Json(new { Msg = "0", Reason = "No row affected!" });
            }
        }


        // POST: api/crmcontact/UpdateAccountSetup/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignPackage/UpdateAssignPackage/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAssignPackage(int id, TMS_AssignPackage tmsAdvertiseCash)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != tmsAdvertiseCash.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _assignPackageBll.Update(tmsAdvertiseCash);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsAdvertiseCashExists(id))
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

        // PUT: api/crmcontact/Delete/id
        [AcceptVerbs("DELETE")]
        [Route("api/TmsAssignPackage/DeleteAssignPackage/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAssignPackage(int id)
        {
            var contact = _assignPackageBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _assignPackageBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _assignPackageBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

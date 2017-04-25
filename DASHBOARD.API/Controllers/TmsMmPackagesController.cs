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
    public class TmsMmPackagesController : ApiController
    {
        private TmsMmPackagesBll _mmPackagesBll;
        public TmsMmPackagesController()
        {
            _mmPackagesBll = new TmsMmPackagesBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMmPackages")]
        [ResponseType(typeof(TMS_MMPackages))]
        public IHttpActionResult GetAllMmPackages()
        {
            var mp = _mmPackagesBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.PackageName,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsMmPackages/GetMmPackagesByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMmPackages/GetMmPackagesByContext/{sValue}")]
        [ResponseType(typeof(TMS_MMPackages))]
        public IHttpActionResult GetMmPackagesByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _mmPackagesBll.GetAll().Where(c => c.PackageName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
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
        [Route("api/TmsMmPackages/GeMmPackagesById/{id}")]
        [ResponseType(typeof(TMS_MMPackages))]
        public IHttpActionResult GetMmPackagesById(int id)
        {
            if (id == 0)
            {
                var mp = _mmPackagesBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
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
        [Route("api/TmsMmPackages")]
        [ResponseType(typeof(TMS_MMPackages))]
        public IHttpActionResult Post(TMS_MMPackages tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _mmPackagesBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsMmPackages/UpdateMmPackages/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMmPackages(int id, TMS_MMPackages tmsAdvertiseCash)
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
                int s = _mmPackagesBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsMmPackages/DeleteMmPackages/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteMmPackages(int id)
        {
            var contact = _mmPackagesBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _mmPackagesBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _mmPackagesBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

   
}

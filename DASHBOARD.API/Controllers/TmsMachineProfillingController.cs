using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineProfillingController : ApiController
    {
        private TmsMachineProfillingBll _machineProfillingBll;
        public TmsMachineProfillingController()
        {
            _machineProfillingBll = new TmsMachineProfillingBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineProfilling")]
        [ResponseType(typeof(Asset_FixedAssets))]
        public IHttpActionResult GetAllMachineProfilling()
        {
            var mp = _machineProfillingBll.GetAll().OrderBy(c => c.Entry);
            return Ok(mp.ToList());
        }

        //GET: api/TmsMachineProfilling/GetMachineProfillingByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineProfilling/GetMachineProfillingByContext/{sValue}")]
        [ResponseType(typeof(Asset_FixedAssets))]
        public IHttpActionResult GetMachineProfillingByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _machineProfillingBll.GetAll()
                    .Where(c => c.Version.Contains(sValue))
                    .OrderBy(c => c.Entry).ToList().ToList();
                return Ok(context.ToList());
            }

            return Json(new { Msg = "0", Reason = "Empty result set!" });
        }

        //GET: api/crmcontact
        [Route("api/TmsMachineProfilling/GeMachineProfillingById/{id}")]
        [ResponseType(typeof(Asset_FixedAssets))]
        public IHttpActionResult GetMachineProfillingById(int id)
        {
            if (id != 0)
            {
                var mp = _machineProfillingBll.GetAll().Where(i => i.Id.Equals(id));
                   return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineProfilling")]
        [ResponseType(typeof(Asset_FixedAssets))]
        public IHttpActionResult Post(Asset_FixedAssets tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _machineProfillingBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsMachineProfilling/UpdateMachineProfilling/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMachineProfilling(int id, Asset_FixedAssets tmsAdvertiseCash)
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
                int s = _machineProfillingBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsMachineProfilling/DeleteMachineProfilling/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteMachineProfilling(int id)
        {
            var contact = _machineProfillingBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _machineProfillingBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _machineProfillingBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

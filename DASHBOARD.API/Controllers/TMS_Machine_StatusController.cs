using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineStatusController : ApiController
    {
        private TmsMachineStatusBll _msBll;
        public TmsMachineStatusController()
        {
            _msBll = new TmsMachineStatusBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineStatus")]
        [ResponseType(typeof(TMS_Machine_Status))]
        public IHttpActionResult GetAllMachineProfilling()
        {
            var mp = _msBll.GetAll().OrderBy(c => c.Entry);
            return Ok(mp.ToList());
        }

        //GET: api/TmsMachineStatus/GetMachineProfillingByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineStatus/GetMachineProfillingByContext/{sValue}")]
        [ResponseType(typeof(TMS_Machine_Status))]
        public IHttpActionResult GetMachineProfillingByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _msBll.GetAll()
                    .Where(c => c.Description.Contains(sValue))
                    .OrderBy(c => c.Entry).ToList().ToList();
                return Ok(context.ToList());
            }

            return Json(new { Msg = "0", Reason = "Empty result set!" });
        }

        //GET: api/crmcontact
        [Route("api/TmsMachineStatus/GeMachineProfillingById/{id}")]
        [ResponseType(typeof(TMS_Machine_Status))]
        public IHttpActionResult GetMachineProfillingById(int id)
        {
            if (id != 0)
            {
                var mp = _msBll.GetAll().Where(i => i.Id.Equals(id));
                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });
        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineStatus")]
        [ResponseType(typeof(TMS_Machine_Status))]
        public IHttpActionResult Post(TMS_Machine_Status ad)
        {
            if (ad == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _msBll.Insert(ad);
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
        [Route("api/TmsMachineStatus/UpdateMachineProfilling/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMachineProfilling(int id, TMS_Machine_Status ac)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != ac.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _msBll.Update(ac);
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
        [Route("api/TmsMachineStatus/DeleteMachineProfilling/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteMachineProfilling(int id)
        {
            var contact = _msBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _msBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _msBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }



    //public class TmsMachineStatusRepository
    //{
    //    private PillarsaltDbContext _dbContext;
    //    private int _s;
    //    public TmsMachineStatusRepository()
    //    {
    //        _dbContext = new PillarsaltDbContext();
    //    }

    //    public IEnumerable<TMS_Machine_Status> GetAll()
    //    {
    //        return _dbContext.TMS_Machine_Status.ToList();
    //    }

    //    public int Update(TMS_Machine_Status tmsMobility)
    //    {
    //        _dbContext.Entry(tmsMobility).State = EntityState.Modified;
    //        _s = Save();
    //        return _s;
    //    }

    //    public int Delete(int id)
    //    {
    //        TMS_Machine_Status tmsMobility = _dbContext.TMS_Machine_Status.Find(id);
    //        if (tmsMobility != null)
    //        {
    //            _dbContext.TMS_Machine_Status.Remove(tmsMobility);
    //            _s = Save();
    //            return _s;
    //        }
    //        return _s;
    //    }

    //    public int Insert(TMS_Machine_Status tmsMobility)
    //    {
    //        _dbContext.TMS_Machine_Status.Add(tmsMobility);
    //        _s = Save();
    //        return _s;
    //    }

    //    private int Save()
    //    {
    //        return _dbContext.SaveChanges();
    //    }


    //}
}

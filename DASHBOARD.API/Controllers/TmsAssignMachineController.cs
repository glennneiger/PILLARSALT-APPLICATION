using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAssignMachineController : ApiController
    {
        private TmsAssignMachineBll _assignMachineBll;
        public TmsAssignMachineController()
        {
            _assignMachineBll = new TmsAssignMachineBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignMachine")]
        [ResponseType(typeof(TMS_AssignMachine))]
        public IHttpActionResult GetAllAssignMachine()
        {
            var mp = _assignMachineBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.MachineName,
                            a.CustodianName,
                            a.CustodianPhone,
                            a.Active,
                            a.Entry,
                            a.Machine_Location_Id

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsAssignMachine/GetMachineProfillingByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignMachine/GetAssignMachineByContext/{sValue}")]
        [ResponseType(typeof(TMS_AssignMachine))]
        public IHttpActionResult GetAssignMachineByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _assignMachineBll.GetAll().Where(c => c.MachineName.Contains(sValue) || c.CustodianName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.MachineName,
                                a.CustodianName,
                                a.CustodianPhone,
                                a.Active,
                                a.Entry,
                                a.Machine_Location_Id
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsAssignMachine/GeAssignMachineById/{id}")]
        [ResponseType(typeof(TMS_AssignMachine))]
        public IHttpActionResult GetMachineProfillingById(int id)
        {
            if (id != 0)
            {
                var mp = _assignMachineBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.MachineName,
                        a.CustodianName,
                        a.CustodianPhone,
                        a.Active,
                        a.Entry,
                        a.Machine_Location_Id
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignMachine")]
        [ResponseType(typeof(TMS_AssignMachine))]
        public IHttpActionResult Post(TMS_AssignMachine tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _assignMachineBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsAssignMachine/UpdateAssignMachine/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAssignMachine(int id, TMS_AssignMachine tmsAdvertiseCash)
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
                int s = _assignMachineBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsAssignMachine/DeleteAssignMachine/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAssignMachine(int id)
        {
            var contact = _assignMachineBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _assignMachineBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _assignMachineBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

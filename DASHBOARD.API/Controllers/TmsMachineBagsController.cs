using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using DASHBOARD.API.Models;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineBagsController : ApiController
    {
        private TmsMachineBagsBll _machineBagsBll;

        public TmsMachineBagsController()
        {
            _machineBagsBll = new TmsMachineBagsBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBags")]
        [ResponseType(typeof(TMS_MachineBags))]
        public IHttpActionResult GetAllMachineBags()
        {
            PillarsaltDbContext db = new PillarsaltDbContext();
            BagViewModel bagViewModel = new BagViewModel();
            bagViewModel.TmsMachineBagses = db.TMS_MachineBags.ToList();
            bagViewModel.TmsDepositeBags = db.TMS_DepositeBag.ToList().ToList();
            bagViewModel.TmsMachineBrands = db.TMS_Machine_BrandandModels.ToList();

            var qry = from d in _machineBagsBll.GetAll()
                      join b in bagViewModel.TmsMachineBrands on d.MachineId equals b.Id
                      join t in bagViewModel.TmsMachineDocumentses on d.MachineId equals t.Id
                      join p in bagViewModel.TmsDepositeBags on d.BagId equals p.Id

                      select new
                      {
                          t.MachineName,
                          machineId = b.Id,
                          mBagNo = p.BagNo,
                          d.Id,
                          d.Notes,
                          d.MachineId,
                          d.BagId,
                          d.StaffId,
                          d.Amount,
                          d.CurrentStage,
                          d.UserId,
                          d.AttachDate,
                          d.Active
                      };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetMachineBagsMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBags/GetMachineBagsById/{id}")]
        [ResponseType(typeof(TMS_MachineBags))]
        public IHttpActionResult GetMachineBagsById(int id)
        {

            var contact = _machineBagsBll.GetById(id);
            if (contact.Any())
            {

                PillarsaltDbContext db = new PillarsaltDbContext();
                BagViewModel bagViewModel = new BagViewModel
                {
                    TmsMachineBagses = db.TMS_MachineBags.ToList(),
                    TmsDepositeBags = db.TMS_DepositeBag.ToList().ToList(),
                    TmsMachineDocumentses = db.TMS_Machine_Documents.ToList()
                };
                var qry = from d in _machineBagsBll.GetById(id)
                          join b in bagViewModel.TmsMachineDocumentses on d.MachineId equals b.Id
                          join p in bagViewModel.TmsDepositeBags on d.BagId equals p.Id

                          select new
                          {
                              b.MachineName,
                              machineId = b.Id,
                              mBagNo = p.BagNo,
                              d.Id,
                              d.Notes,
                              d.MachineId,
                              d.BagId,
                              d.StaffId,
                              d.Amount,
                              d.CurrentStage,
                              d.UserId,
                              d.AttachDate,
                              d.Active
                          };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });
            }

        }

        //GET: api/TmsMachineBags/GetMachineBagsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineBags/GetMachineBagsByContext/{sValue}")]
        [ResponseType(typeof(TMS_MachineBags))]
        public IHttpActionResult GetMachineBagsByContext(string sValue)
        {

            if (sValue != null)
            {
                PillarsaltDbContext db = new PillarsaltDbContext();
                BagViewModel bagViewModel = new BagViewModel
                {
                    TmsMachineBagses = db.TMS_MachineBags.ToList(),
                    TmsDepositeBags = db.TMS_DepositeBag.ToList().ToList(),
                    TmsMachineDocumentses = db.TMS_Machine_Documents.ToList()
                };
                var qry = from d in _machineBagsBll.GetAll().Where(m => m.MachineId != null && m.MachineId.Equals(sValue))
                          join b in bagViewModel.TmsMachineDocumentses on d.MachineId equals b.Id
                          join p in bagViewModel.TmsDepositeBags on d.BagId equals p.Id

                          select new
                          {
                              b.MachineName,
                              machineId = b.Id,
                              mBagNo = p.BagNo,
                              d.Id,
                              d.Notes,
                              d.MachineId,
                              d.BagId,
                              d.StaffId,
                              d.Amount,
                              d.CurrentStage,
                              d.UserId,
                              d.AttachDate,
                              d.Active
                          };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineBags")]
        [ResponseType(typeof(TMS_MachineBags))]
        public IHttpActionResult Post(TMS_MachineBags accountsMachineBagsDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _machineBagsBll.Insert(accountsMachineBagsDetails);
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


        // PUT: api/AccAccountsMachineBagsDetails/UpdateAccountsMachineBagsDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineBags/UpdateMachineBags")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMachineBags(int id, TMS_MachineBags mb)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != mb.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _machineBagsBll.Update(mb);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineBagsMappingExists(id))
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
        [Route("api/TmsMachineBags/DeleteMachineBags/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _machineBagsBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _machineBagsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool MachineBagsMappingExists(int id)
        {
            return _machineBagsBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsManageBankController : ApiController
    {
        private TmsManageBankBll _manageBankBll;
        public TmsManageBankController()
        {
            _manageBankBll = new TmsManageBankBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsManageBank")]
        [ResponseType(typeof(TMS_Manage_Bank))]
        public IHttpActionResult GetAllManageBank()
        {
            var mp = _manageBankBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.BankName,
                            a.Active,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsManageBank/GetManageBankByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsManageBank/GetManageBankByContext/{sValue}")]
        [ResponseType(typeof(TMS_Manage_Bank))]
        public IHttpActionResult GetManageBankByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _manageBankBll.GetAll().Where(c => c.BankName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.BankName,
                                a.Notes,
                                a.Active,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsManageBank/GeManageBankById/{id}")]
        [ResponseType(typeof(TMS_Manage_Bank))]
        public IHttpActionResult GetManageBankById(int id)
        {
            if (id == 0)
            {
                var mp = _manageBankBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.BankName,
                        a.Active,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsManageBank")]
        [ResponseType(typeof(TMS_Manage_Bank))]
        public IHttpActionResult Post(TMS_Manage_Bank tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _manageBankBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsManageBank/UpdateManageBank/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateManageBank(int id, TMS_Manage_Bank tmsAdvertiseCash)
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
                int s = _manageBankBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsManageBank/DeleteManageBank/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteManageBank(int id)
        {
            var contact = _manageBankBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _manageBankBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _manageBankBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsDepositBagController : ApiController
    {
        private TmsDepositBagBll _bagBll;
        public TmsDepositBagController()
        {
            _bagBll = new TmsDepositBagBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/TmsDepositBag")]
        [ResponseType(typeof(TMS_DepositeBag))]
        public IHttpActionResult GetAllDepositBag()
        {
            var qry = _bagBll.GetAll()
                .Select(
                    d =>
                        new
                        {
                            d.Id,
                            d.BagNo,
                            d.PurchaseDate,
                            d.CommisionDate,
                            d.CurrentStage,
                            d.CreationDate,
                            d.Notes,
                            d.Entry,
                            d.Active
                        }).OrderBy(e => e.Entry);
            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetDepositBagMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsDepositBag/GetDepositBagById/{id}")]
        [ResponseType(typeof(TMS_DepositeBag))]
        public IHttpActionResult GetDepositBagById(int id)
        {

            var contact = _bagBll.GetById(id);
            if (contact.Any())
            {

                var qry = _bagBll.GetById(id)
                          .Select(d => new
                          {
                              d.Id,
                              d.BagNo,
                              d.PurchaseDate,
                              d.CommisionDate,
                              d.CurrentStage,
                              d.CreationDate,
                              d.Notes,
                              d.Entry,
                              d.Active
                          }).OrderBy(e => e.Entry);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/TmsDepositBag/GetDepositBagByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsDepositBag/GetDepositBagByContext/{sValue}")]
        [ResponseType(typeof(TMS_DepositeBag))]
        public IHttpActionResult GetDepositBagByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = _bagBll.GetAll().Where(c => c.BagNo.Equals(sValue))
                          .Select(d => new
                          {
                              d.Id,
                              d.BagNo,
                              d.PurchaseDate,
                              d.CommisionDate,
                              d.CurrentStage,
                              d.CreationDate,
                              d.Notes,
                              d.Entry,
                              d.Active
                          }).OrderBy(e => e.Entry);

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsDepositBag")]
        [ResponseType(typeof(TMS_DepositeBag))]
        public IHttpActionResult Post(TMS_DepositeBag accountsDepositBagDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _bagBll.Insert(accountsDepositBagDetails);
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


        // PUT: api/AccAccountsDepositBagDetails/UpdateAccountsDepositBagDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsDepositBag/UpdateDepositBag")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateDepositBag(int id, TMS_DepositeBag accountsDepositBagDetails)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != accountsDepositBagDetails.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _bagBll.Update(accountsDepositBagDetails);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositBagMappingExists(id))
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
        [Route("api/TmsDepositBag/DeleteDepositBag/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _bagBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _bagBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool DepositBagMappingExists(int id)
        {
            return _bagBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsCustomerStatementController : ApiController
    {
        private TmsCustomerStatementBll _customerStatementBll;
        public TmsCustomerStatementController()
        {
            _customerStatementBll = new TmsCustomerStatementBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsCustomerStatement")]
        [ResponseType(typeof(TMS_Customer_Statement))]
        public IHttpActionResult GetAllCustomerStatement()
        {
            var mp = _customerStatementBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.CustomerName,
                            a.CustomerAccountNo,
                            a.TelNo,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsCustomerStatement/GetCustomerStatementByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsCustomerStatement/GetCustomerStatementByContext/{sValue}")]
        [ResponseType(typeof(TMS_Customer_Statement))]
        public IHttpActionResult GetCustomerStatementByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _customerStatementBll.GetAll().Where(c => c.CustomerName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.CustomerName,
                                a.CustomerAccountNo,
                                a.TelNo,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsCustomerStatement/GeCustomerStatementById/{id}")]
        [ResponseType(typeof(TMS_Customer_Statement))]
        public IHttpActionResult GetCustomerStatementById(int id)
        {
            if (id == 0)
            {
                var mp = _customerStatementBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.CustomerName,
                        a.CustomerAccountNo,
                        a.TelNo,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsCustomerStatement")]
        [ResponseType(typeof(TMS_Customer_Statement))]
        public IHttpActionResult Post(TMS_Customer_Statement tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _customerStatementBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsCustomerStatement/UpdateCustomerStatement/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCustomerStatement(int id, TMS_Customer_Statement tmsAdvertiseCash)
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
                int s = _customerStatementBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsCustomerStatement/DeleteCustomerStatement/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCustomerStatement(int id)
        {
            var contact = _customerStatementBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _customerStatementBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _customerStatementBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

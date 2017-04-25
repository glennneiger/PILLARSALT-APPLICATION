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
    public class TmsTransactionDetailsController : ApiController
    {
        private TmsTransactionDetailsBll _transactionDetailsBll;
        public TmsTransactionDetailsController()
        {
            _transactionDetailsBll = new TmsTransactionDetailsBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsTransactionDetails")]
        [ResponseType(typeof(TMS_TransactionDetails))]
        public IHttpActionResult GetAllTransactionDetails()
        {
            var mp = _transactionDetailsBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.AcctName,
                            a.AcctNo,
                            a.TransactionAmount,
                            a.SenderName,
                            a.Sender_AcctNo,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsTransactionDetails/GetTransactionDetailsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsTransactionDetails/GetTransactionDetailsByContext/{sValue}")]
        [ResponseType(typeof(TMS_TransactionDetails))]
        public IHttpActionResult GetTransactionDetailsByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _transactionDetailsBll.GetAll().Where(c => c.AcctName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.AcctName,
                                a.AcctNo,
                                a.TransactionAmount,
                                a.SenderName,
                                a.Sender_AcctNo,
                                a.Notes,
                                a.Entry

                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsTransactionDetails/GeTransactionDetailsById/{id}")]
        [ResponseType(typeof(TMS_TransactionDetails))]
        public IHttpActionResult GetTransactionDetailsById(int id)
        {
            if (id == 0)
            {
                var mp = _transactionDetailsBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.AcctName,
                        a.AcctNo,
                        a.TransactionAmount,
                        a.SenderName,
                        a.Sender_AcctNo,
                        a.Notes,
                        a.Entry

                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsTransactionDetails")]
        [ResponseType(typeof(TMS_TransactionDetails))]
        public IHttpActionResult Post(TMS_TransactionDetails tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _transactionDetailsBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsTransactionDetails/UpdateTransactionDetails/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateTransactionDetails(int id, TMS_TransactionDetails tmsAdvertiseCash)
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
                int s = _transactionDetailsBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsTransactionDetails/DeleteTransactionDetails/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTransactionDetails(int id)
        {
            var contact = _transactionDetailsBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _transactionDetailsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _transactionDetailsBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

   

    
}

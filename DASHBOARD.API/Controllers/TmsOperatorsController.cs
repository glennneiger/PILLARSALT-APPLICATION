using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsOperatorsController : ApiController
    {
        private TmsOperatorsBll _operatorsBll;
        public TmsOperatorsController()
        {
            _operatorsBll = new TmsOperatorsBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsOperators")]
        [ResponseType(typeof(TMS_Operators))]
        public IHttpActionResult GetAllTmsOperators()
        {
            var mp = _operatorsBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.OperatorName,
                            a.OperatorAcct,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsOperators/GetTmsOperatorsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsOperators/GetTmsOperatorsByContext/{sValue}")]
        [ResponseType(typeof(TMS_Operators))]
        public IHttpActionResult GetTmsOperatorsByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _operatorsBll.GetAll().Where(c => c.OperatorName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.OperatorName,
                                a.OperatorAcct,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsOperators/GeTmsOperatorsById/{id}")]
        [ResponseType(typeof(TMS_Operators))]
        public IHttpActionResult GetTmsOperatorsById(int id)
        {
            if (id == 0)
            {
                var mp = _operatorsBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.OperatorName,
                        a.OperatorAcct,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsOperators")]
        [ResponseType(typeof(TMS_Operators))]
        public IHttpActionResult Post(TMS_Operators tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _operatorsBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsOperators/UpdateTmsOperators/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateTmsOperators(int id, TMS_Operators tmsAdvertiseCash)
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
                int s = _operatorsBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsOperators/DeleteTmsOperators/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTmsOperators(int id)
        {
            var contact = _operatorsBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _operatorsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _operatorsBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

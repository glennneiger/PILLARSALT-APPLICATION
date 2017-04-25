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
    public class AccRetirementsController : ApiController
    {
        private AccRetirementsBll _accRetirementsBll;

        public AccRetirementsController()
        {
            _accRetirementsBll = new AccRetirementsBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/AccRetirements")]
        [ResponseType(typeof(Acc_Retirements))]
        public IHttpActionResult GetAllRetirements()
        {
            var qry = from d in _accRetirementsBll.GetAll()
                      select new { d.Id, d.Description, d.Active };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/AccRetirements/GetRetirementsById/{id}")]
        [ResponseType(typeof(Acc_Retirements))]
        public IHttpActionResult GetRetirementsById(int id)
        {

            var contact = _accRetirementsBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _accRetirementsBll.GetById(id)
                          select new { d.Id, d.Description, d.Active };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/AccRetirements/GetRetirementsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccRetirements/GetRetirementsByContext/{sValue}")]
        [ResponseType(typeof(Acc_Retirements))]
        public IHttpActionResult GetRetirementsByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _accRetirementsBll.GetAll().Where(c => c.Description.Contains(sValue))
                          select new { d.Id, d.Description, d.Active };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccRetirements")]
        [ResponseType(typeof(Acc_Retirements))]
        public IHttpActionResult Post(Acc_Retirements accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _accRetirementsBll.Insert(accountsBankDetails);
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


        // PUT: api/AccAccountsBankDetails/UpdateAccountsBankDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/AccRetirements/UpdateRetirements")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateRetirements(int id, Acc_Retirements accountsBankDetails)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != accountsBankDetails.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _accRetirementsBll.Update(accountsBankDetails);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankMappingExists(id))
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
        [Route("api/AccRetirements/DeleteRetirements/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _accRetirementsBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _accRetirementsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool BankMappingExists(int id)
        {
            return _accRetirementsBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }
  
}

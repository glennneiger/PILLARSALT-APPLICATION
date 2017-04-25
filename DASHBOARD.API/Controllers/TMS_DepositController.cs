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
using PillarSalt.DAL_REPO;

namespace DASHBOARD.API.Controllers
{
    public class TmsDepositController : ApiController
    {
        private TmsDepositBll _tmsDepositBll;

        public TmsDepositController()
        {
            _tmsDepositBll = new TmsDepositBll();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/TmsDeposit")]
        [ResponseType(typeof(TMS_Deposit))]
        public IHttpActionResult GetAllDeposit()
        {
            var qry = from d in _tmsDepositBll.GetAll()
                      select new { d.Id, d.MachineId, d.Active };

            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetDepositMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsDeposit/GetDepositById/{id}")]
        [ResponseType(typeof(TMS_Deposit))]
        public IHttpActionResult GetDepositById(int id)
        {

            var contact = _tmsDepositBll.GetById(id);
            if (contact.Any())
            {

                var qry = from d in _tmsDepositBll.GetById(id)
                          select new { d.Id, d.MachineId, d.Active };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/TmsDeposit/GetDepositByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsDeposit/GetDepositByContext/{sValue}")]
        [ResponseType(typeof(TMS_Deposit))]
        public IHttpActionResult GetDepositByContext(string sValue)
        {

            if (sValue != null)
            {
                var qry = from d in _tmsDepositBll.GetAll().Where(c => c.MachineId.Equals(sValue)) 
                          select new { d.Id, d.MachineId, d.Active };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsDeposit")]
        [ResponseType(typeof(TMS_Deposit))]
        public IHttpActionResult Post(TMS_Deposit accountsDepositDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _tmsDepositBll.Insert(accountsDepositDetails);
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


        // PUT: api/AccAccountsDepositDetails/UpdateAccountsDepositDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsDeposit/UpdateDeposit")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateDeposit(int id, TMS_Deposit accountsDepositDetails)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != accountsDepositDetails.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _tmsDepositBll.Update(accountsDepositDetails);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositMappingExists(id))
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
        [Route("api/TmsDeposit/DeleteDeposit/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _tmsDepositBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _tmsDepositBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool DepositMappingExists(int id)
        {
            return _tmsDepositBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }

    

    
}

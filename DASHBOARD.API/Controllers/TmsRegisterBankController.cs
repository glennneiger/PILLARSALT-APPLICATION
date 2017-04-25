﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsRegisterBankController : ApiController
    {
        private TmsRegisterBankhBll _registerBankhBll;
        public TmsRegisterBankController()
        {
            _registerBankhBll = new TmsRegisterBankhBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsRegisterBank")]
        [ResponseType(typeof(TMS_Register_Bank))]
        public IHttpActionResult GetAllRegisterBank()
        {
            var mp = _registerBankhBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.BankName,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsRegisterBank/GetRegisterBankByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsRegisterBank/GetRegisterBankByContext/{sValue}")]
        [ResponseType(typeof(TMS_Register_Bank))]
        public IHttpActionResult GetRegisterBankByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _registerBankhBll.GetAll().Where(c => c.BankName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.BankName,
                                a.Notes,
                                a.Entry

                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsRegisterBank/GeRegisterBankById/{id}")]
        [ResponseType(typeof(TMS_Register_Bank))]
        public IHttpActionResult GetRegisterBankById(int id)
        {
            if (id == 0)
            {
                var mp = _registerBankhBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.BankName,
                        a.Notes,
                        a.Entry

                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsRegisterBank")]
        [ResponseType(typeof(TMS_Register_Bank))]
        public IHttpActionResult Post(TMS_Register_Bank tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _registerBankhBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsRegisterBank/UpdateRegisterBank/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateRegisterBank(int id, TMS_Register_Bank tmsAdvertiseCash)
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
                int s = _registerBankhBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsRegisterBank/DeleteRegisterBank/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteRegisterBank(int id)
        {
            var contact = _registerBankhBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _registerBankhBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _registerBankhBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

  
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using DASHBOARD.API.Models;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class AccBankMappingController : ApiController
    {
        private AccBankMappingBll _bankMappingBll;
        private BankAccountViewModel _batViewModel;
        private PillarsaltDbContext _db;
        public AccBankMappingController()
        {
            _batViewModel = new BankAccountViewModel();
            _bankMappingBll = new AccBankMappingBll();
            _db = new PillarsaltDbContext();
        }


        //GET: api/AccBankMapping
        [AcceptVerbs("GET")]
        [Route("api/AccBankMapping")]
        [ResponseType(typeof(Acc_BankMapping))]
        public IHttpActionResult GetAllBankMapping()
        {
            _batViewModel.AccBanks = _db.ACCBanks.ToList();
            _batViewModel.Accounts = _db.Accounts.ToList();
            _batViewModel.AccCurrencyCodes = _db.Acc_CurrencyCode.ToList();

            var qry = from d in _bankMappingBll.GetAll()
                      join b in _batViewModel.AccBanks on d.BankId equals b.Id
                      join q in _batViewModel.AccCurrencyCodes on d.CurrencyId equals q.Id
                      //join a in _batViewModel.Accounts on d.AccountId equals a.SerialAcc

                      select new { d.Id, d.Description, d.NUBAN, NameOfBank = b.BankName, CurrencyType = q.Description };

            return Ok(qry.ToList());
        }

        //GET: api/AccBankMapping/GetBankMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/AccBankMapping/GetBankMappingById/{id}")]
        [ResponseType(typeof(Acc_BankMapping))]
        public IHttpActionResult GetBankMappingById(int id)
        {

            var contact = _bankMappingBll.GetById(id);
            if (contact.Any())
            {
                _batViewModel.AccBanks = _db.ACCBanks.ToList();
                _batViewModel.Accounts = _db.Accounts.ToList();
                _batViewModel.AccCurrencyCodes = _db.Acc_CurrencyCode.ToList();

                var qry = from d in _bankMappingBll.GetById(id)
                          join b in _batViewModel.AccBanks on d.BankId equals b.Id
                          join q in _batViewModel.AccCurrencyCodes on d.CurrencyId equals q.Id
                          //join a in _batViewModel.Accounts on d.AccountId equals a.SerialAcc

                          select new { d.Id, d.Description, d.NUBAN, NameOfBank = b.BankName, CurrencyType = q.Description };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        //GET: api/AccAccountsBankDetails/GetAccountsBankDetailsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccBankMapping/GetBankMappingByContext/{sValue}")]
        [ResponseType(typeof(Acc_BankMapping))]
        public IHttpActionResult GetBankMappingByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _bankMappingBll.GetAll().Where(c => c.Description.Contains(sValue))
                    .Select(c => new
                    {
                        c.Id,
                        c.Description,
                        c.Active,
                        c.Entry
                    }).OrderBy(c => c.Entry).ToList();

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/AccBankMapping")]
        [ResponseType(typeof(Acc_BankMapping))]
        public IHttpActionResult Post(Acc_BankMapping accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _bankMappingBll.Insert(accountsBankDetails);
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
        [Route("api/AccBankMapping/UpdateBankMapping")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateBankMapping(int id, Acc_BankMapping accountsBankDetails)
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
                int s = _bankMappingBll.Update(accountsBankDetails);
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
        [Route("api/AccBankMapping/DeleteBankMapping")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBankMapping(int id)
        {
            var contact = _bankMappingBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _bankMappingBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool BankMappingExists(int id)
        {
            return _bankMappingBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }



    
}

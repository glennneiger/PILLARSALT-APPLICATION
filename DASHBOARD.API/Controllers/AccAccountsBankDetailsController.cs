using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using DASHBOARD.API.Models;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class AccAccountsBankDetailsController : ApiController
    {
        private AccAccountsBankDetailsBll _accountsBankDetailsBll;
        private BankAccountViewModel _batViewModel;
        private PillarsaltDbContext _db;
        public AccAccountsBankDetailsController()
        {
            _batViewModel = new BankAccountViewModel();
            _accountsBankDetailsBll = new AccAccountsBankDetailsBll();
            _db = new PillarsaltDbContext();
        }


        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/AccAccountsBankDetails")]
        [ResponseType(typeof(Acc_Accounts_BankDetails))]
        public IHttpActionResult GetAllAccountsBankDetails()
        {
            _batViewModel.AccBanks = _db.ACCBanks.ToList();
            _batViewModel.Accounts = _db.Accounts.ToList();
            _batViewModel.AccCurrencyCodes = _db.Acc_CurrencyCode.ToList();

            var qry = from d in _accountsBankDetailsBll.GetAll()
                      join b in _batViewModel.AccBanks on d.BankId equals b.Id
                      join q in _batViewModel.AccCurrencyCodes on d.CurrencyId equals q.Id
                      join a in _batViewModel.Accounts on d.AccountId equals a.SerialAcc

                      select new { d.Id, d.Description, d.NUBAN, AccountNameNumber = a.AccountName + " - " + a.AccountNo, NameOfBank = b.BankName, CurrencyType = q.Description };

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/AccAccountsBankDetails/GetAccountsBankDetailsById/{id}")]
        [ResponseType(typeof(Acc_Accounts_BankDetails))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetAccountsBankDetailsById(int id)
        {

            var contact = _accountsBankDetailsBll.GetById(id);
            if (contact.Any())
            {
                _batViewModel.AccBanks = _db.ACCBanks.ToList();
                _batViewModel.Accounts = _db.Accounts.ToList();
                _batViewModel.AccCurrencyCodes = _db.Acc_CurrencyCode.ToList();
                _batViewModel.AspnetUserses = _db.aspnet_Users.ToList();

                var qry = from d in _accountsBankDetailsBll.GetById(id)
                          join b in _batViewModel.AccBanks on d.BankId equals b.Id
                          join q in _batViewModel.AccCurrencyCodes on d.CurrencyId equals q.Id
                          join a in _batViewModel.Accounts on d.AccountId equals a.SerialAcc

                          select new { d.Id, d.Description, d.NUBAN, AccountNameNumber = a.AccountName + " - " + a.AccountNo, NameOfBank = b.BankName, CurrencyType = q.Description };

                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        //GET: api/AccAccountsBankDetails/GetAccountsBankDetailsByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/AccAccountsBankDetails/GetAccountsBankDetailsByContext/{sValue}")]
        [ResponseType(typeof(Acc_Accounts_BankDetails))]
        public IHttpActionResult GetAccountsBankDetailsByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _accountsBankDetailsBll.GetAll().Where(c => c.Description.Contains(sValue))
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
        [Route("api/AccAccountsBankDetails/")]
        [ResponseType(typeof(Acc_Accounts_BankDetails))]
        public IHttpActionResult Post(Acc_Accounts_BankDetails accountsBankDetails)
        {
            if (ModelState.IsValid)
            {
                int c = _accountsBankDetailsBll.Insert(accountsBankDetails);
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
        [Route("api/AccAccountsBankDetails/UpdateAccountsBankDetails/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAccountsBankDetails(int id, Acc_Accounts_BankDetails accountsBankDetails)
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
                int s = _accountsBankDetailsBll.Update(accountsBankDetails);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteAccountsBankDetailsExists(id))
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
        [Route("api/AccAccountsBankDetails/DeleteAccountsBankDetails/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAccountsBankDetails(int id)
        {
            var contact = _accountsBankDetailsBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _accountsBankDetailsBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteAccountsBankDetailsExists(int id)
        {
            return _accountsBankDetailsBll.GetAll().Count(e => e.Id == id) > 0;
        }


    }
}

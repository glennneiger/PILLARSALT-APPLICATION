using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class CrmContactController : ApiController
    {
        private CrmContactBll _objContactBll;
        public CrmContactController()
        {
            _objContactBll = new CrmContactBll();
        }


        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/crmcontact")]
        [ResponseType(typeof(CRMContact))]
        public IHttpActionResult GetAllContact()
        {
            var contact = _objContactBll.GetAll()
                .Select(
                    c =>
                        new
                        {
                            c.ContactID,
                            c.Salutation,
                            c.FirstName,
                            c.LastName,
                            c.MiddleName,
                            c.FullName,
                            c.MobileNo,
                            c.BusinessNo,
                            c.JobTitle,
                            c.CreditLimit,
                            c.Email,
                            c.Active,
                            c.DOB,
                            c.Nationality,
                            c.Notes,
                            c.Photo,
                            c.Language,
                            c.Address,
                            c.PostalCode,
                            c.CityCode,
                            c.StateCode,
                            c.ShippingMethod,
                            c.Entry,
                            c.UserId,
                            c.Gender,
                            c.ParentContactID,
                            c.RelationshipId,
                            c.FingerPrint,
                            c.Signature,
                            c.Religion
                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.FirstName);
            return Ok(contact.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/CrmContact/GetContactById/{id}")]
        [ResponseType(typeof(CRMContact))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetContactById(int id)
        {

            var contact = _objContactBll.GetById(id);
            if (contact != null)
            {
                var contact2 = _objContactBll.GetAll()
                    .Select(
                        c => new
                        {
                            c.ContactID,
                            c.PrimaryEntityID,
                            c.Salutation,
                            c.FirstName,
                            c.LastName,
                            c.MiddleName,
                            c.FullName,
                            c.MobileNo,
                            c.BusinessNo,
                            c.JobTitle,
                            c.CreditLimit,
                            c.Email,
                            c.Active,
                            c.DOB,
                            c.Nationality,
                            c.Notes,
                            c.Photo,
                            c.Language,
                            c.Address,
                            c.PostalCode,
                            c.CityCode,
                            c.StateCode,
                            c.ShippingMethod,
                            c.Entry,
                            c.UserId,
                            c.Gender,
                            c.ParentContactID,
                            c.RelationshipId,
                            c.FingerPrint,
                            c.Signature,
                            c.Religion
                        }
                    )
                    .Where(c => c.ContactID == id);

                return Ok(contact2);
            }
            else
            {
                return Json(new { Msg = "0" });

            }

        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/CrmContact/GetContactByContext/{sValue}")]
        [ResponseType(typeof(CRMContact))]
        public IHttpActionResult GetContactByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objContactBll.GetAll().Where(c => c.FullName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        c =>
                            new
                            {
                                c.ContactID,
                                c.FullName,
                                c.Active
                            }).OrderBy(c => c.FullName).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }
            return Json(new { Msg = "0" });
        }
        
        [Route("api/TmsDisbursement/GetCrmContactById/{id}")]
        [ResponseType(typeof(CRMContact))]
        public IHttpActionResult GetCrmContactById(int id)
        {
            var contact = _objContactBll.GetAll().Where(c => c.ContactID.Equals(id));
            return Ok(contact.ToList());
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/crmcontact/Post")] //IHttpActionResult HttpResponseMessage
        [ResponseType(typeof(CRMContact))]
        public IHttpActionResult Post(CRMContact crmContact)
        {
            if (ModelState.IsValid)
            {
                int c = _objContactBll.Insert(crmContact);
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


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("POST")]
        [Route("api/crmcontact/UpdateCrmContact/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateContact(int Id, CRMContact crmContact)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (Id != crmContact.ContactID)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _objContactBll.Update(crmContact);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Id))
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
        [Route("api/crmcontact/DeleteCrmContact/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteContact(int id)
        {
            var contact = _objContactBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objContactBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool ContactExists(int Id)
        {
            return _objContactBll.GetAll().Count(e => e.ContactID == Id) > 0;
        }


    }
}

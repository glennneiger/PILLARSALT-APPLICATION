using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsJobProgressionController : ApiController
    {
        private TmsJobProgressionBll _jprogBll;
        public TmsJobProgressionController()
        {
            _jprogBll = new TmsJobProgressionBll();
        }

        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/TmsJobProgression")]
        [ResponseType(typeof(TMS_JobProgression))]
        public IHttpActionResult GetAllJobProgression()
        {
            var qry = _jprogBll.GetAll()
                .OrderBy(e => e.Entry);
            return Ok(qry.ToList());
        }

        //GET: api/AccCurrencyCode/GetJobProgressionMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsJobProgression/GetJobProgressionById/{id}")]
        [ResponseType(typeof(TMS_JobProgression))]
        public IHttpActionResult GetJobProgressionById(int id)
        {
            var contact = _jprogBll.GetById(id);
            if (contact.Any())
            {

                var qry = _jprogBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });
            }

        }

        //GET: api/TmsJobProgression/GetJobProgressionByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsJobProgression/GetJobProgressionByContext/{sValue}")]
        [ResponseType(typeof(TMS_JobProgression))]
        public IHttpActionResult GetJobProgressionByContext(string sValue)
        {
            if (sValue != null)
            {
                var qry = _jprogBll.GetAll()
                    .Where(c => c.JobProgressionName.Contains(sValue))
                    .OrderBy(e => e.Entry);
                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsJobProgression")]
        [ResponseType(typeof(TMS_JobProgression))]
        public IHttpActionResult Post(TMS_JobProgression jp)
        {
            if (ModelState.IsValid)
            {
                int c = _jprogBll.Insert(jp);
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


        // PUT: api/AccAccountsJobProgressionDetails/UpdateAccountsJobProgressionDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsJobProgression/UpdateJobProgression")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateJobProgression(int id, TMS_JobProgression jp)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != jp.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _jprogBll.Update(jp);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobProgressionMappingExists(id))
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
        [Route("api/TmsJobProgression/DeleteJobProgression/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _jprogBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _jprogBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool JobProgressionMappingExists(int id)
        {
            return _jprogBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }

    public class TmsJobProgressionBll
    {
        private TmsJobProgressionRepository _repository;

        public TmsJobProgressionBll()
        {
            _repository = new TmsJobProgressionRepository();
        }

        public IEnumerable<TMS_JobProgression> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public IEnumerable<TMS_JobProgression> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_JobProgression jp)
        {
            return _repository.Insert(jp);
        }

        public int Update(TMS_JobProgression jp)
        {
            return _repository.Update(jp);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }

    public class TmsJobProgressionRepository
    {
        private PillarsaltDbContext _dbContext;
        private int _s;
        public TmsJobProgressionRepository()
        {
            _dbContext = new PillarsaltDbContext();
        }

        public IEnumerable<TMS_JobProgression> GetAll()
        {
            using (_dbContext)
            {
                return _dbContext.TMS_JobProgression.ToList();
            }
        }
        public int Insert(TMS_JobProgression accountsBankDetails)
        {
            _dbContext.TMS_JobProgression.Add(accountsBankDetails);
            return Save();
        }

        private int Save()
        {
            return _dbContext.SaveChanges();
        }

        public int Update(TMS_JobProgression accountsBankDetails)
        {
            _dbContext.Entry(accountsBankDetails).State = EntityState.Modified;
            _s = Save();
            return _s;
        }

        public int Delete(int id)
        {
            TMS_JobProgression accountsBankDetails = _dbContext.TMS_JobProgression.Find(id);
            if (accountsBankDetails != null)
            {
                _dbContext.TMS_JobProgression.Remove(accountsBankDetails);
                _s = Save();
                return _s;
            }
            return _s;
        }



    }
}

using System;
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
    public class TmsAssignTechnicianController : ApiController
    {
        private TmsAssignTechnicianBll _assignTechnicianBll;
        public TmsAssignTechnicianController()
        {
            _assignTechnicianBll = new TmsAssignTechnicianBll();
        }


        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignTechnician")]
        [ResponseType(typeof(TMS_Assign_Technician))]
        public IHttpActionResult GetAllAssignTechnician()
        {
            var qry = _assignTechnicianBll.GetAll();

            return Ok(qry.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsAssignTechnician/GetAssignTechnicianById/{id}")]
        [ResponseType(typeof(TMS_Assign_Technician))]
        public IHttpActionResult GetAssignTechnicianById(int id)
        {

            var contact = _assignTechnicianBll.GetById(id);
            if (contact.Any())
            {
                var qry = _assignTechnicianBll.GetById(id);
                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });

            }

        }

        [AcceptVerbs("GET")]
        [Route("api/TmsAssignTechnician/GetAssignTechnicianByContext/{sValue}")]
        [ResponseType(typeof(TMS_Assign_Technician))]
        public IHttpActionResult GetAssignTechnicianByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = _assignTechnicianBll.GetAll().Where(c => c.TechnicianEmail.Contains(sValue));

                return Ok(context.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignTechnician")]
        [ResponseType(typeof(TMS_Assign_Technician))]
        public IHttpActionResult Post(TMS_Assign_Technician assignTechnician)
        {
            if (assignTechnician.TechnicianId == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Technician Id field cannot be empty!" });
            }
            if (assignTechnician.TechnicianPhone == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Technician Phone field cannot be empty!" });
            }
            if (assignTechnician.TechnicianEmail == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Technician Email field cannot be empty!" });
            }
            if (assignTechnician.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (assignTechnician.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //assign default values before inserting
            assignTechnician.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                int c = _assignTechnicianBll.Insert(assignTechnician);
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

        // PUT: api/TmsAssignTechnician/UpdateAssignTechnician/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsAssignTechnician/UpdateAssignTechnician/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAssignTechnician(int id, TMS_Assign_Technician assignTechnician)
        {
            if (assignTechnician.TechnicianId == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Technician Id field cannot be empty!" });
            }
            if (assignTechnician.TechnicianPhone == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Technician Phone field cannot be empty!" });
            }
            if (assignTechnician.TechnicianEmail == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Technician Email field cannot be empty!" });
            }
            if (assignTechnician.CurrentStage == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Current Stage field cannot be empty!" });
            }
            if (assignTechnician.Notes == String.Empty)
            {
                return Json(new { Msg = "0", Reason = "Note field cannot be empty!" });
            }

            //assign default values before inserting
            assignTechnician.CreationDate = DateTime.Now;


            if (!ModelState.IsValid)
            {
                return Json(new { Msg = "0" });
            }

            if (id != assignTechnician.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _assignTechnicianBll.Update(assignTechnician);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteAssignTechnicianExists(id))
                {
                    //return NotFound();
                    return Json(new { Msg = "0", Reason = "Exception!" });
                }
                else
                {
                    throw;
                }
            }
        }


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("DELETE")]
        [Route("api/TmsAssignTechnician/DeleteAssignTechnician/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAssignTechnician(int id)
        {
            var contact = _assignTechnicianBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _assignTechnicianBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteAssignTechnicianExists(int id)
        {
            return _assignTechnicianBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }




}

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsMachineDocumentController : ApiController
    {
        private TmsMachineDocumentBll _objMachineDocumentBll;

        public TmsMachineDocumentController()
        {
            _objMachineDocumentBll = new TmsMachineDocumentBll();
        }

        //GET: api/TmsMachineDocument
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineDocument")]
        [ResponseType(typeof(TMS_Machine_Documents))]
        public IHttpActionResult GetAllMachineDocument()
        {
            var doc = _objMachineDocumentBll.GetAll()
                .OrderBy(d => d.Entry);
            return Ok(doc.ToList());
        }

        //GET: api/TmsMachineDocument/GetMachineDocumentByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsMachineDocument/GetMachineDocumentByContext/{sValue}")]
        [ResponseType(typeof(TMS_Machine_Locations))]
        public IHttpActionResult GetMachineDocumentByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _objMachineDocumentBll.GetAll()
                    .Where(c => c.Description.Contains(sValue))
                    .OrderBy(c => c.Entry);
                return Ok(context.ToList());
            }
            return Ok(new { Msg = "0", Reason = "Empty Record!" });
        }

        //GET: api/TmsMachineDocument
        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDocument/GetMachineDocumentById/{id}")]
        [ResponseType(typeof(TMS_Machine_Documents))]
        public IHttpActionResult GetMachineDocumentById(int id)
        {
            var disposal = _objMachineDocumentBll.GetAll().Where(c => c.Id.Equals(id));
            return Ok(disposal.ToList());
        }

        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDocument/InsertMachineDocument")]
        [ResponseType(typeof(TMS_Machine_Documents))]
        public IHttpActionResult InsertMachineDocument(TMS_Machine_Documents tmsMachineDocuments)
        {
            if (tmsMachineDocuments == null)
            {
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineDocumentBll.Insert(tmsMachineDocuments);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });
                }
                return Ok(new { Msg = "0" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0", Reason = "No row affected!" });
            }
        }



        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDocument/UpdateMachineDocument")]
        [ResponseType(typeof(TMS_Machine_Documents))]
        public IHttpActionResult UpdateMachineDocument(int id, TMS_Machine_Documents tmsMachineDocuments)
        {
            if (tmsMachineDocuments == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsMachineDocuments.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _objMachineDocumentBll.Update(tmsMachineDocuments);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsMobilityExists(id))
                {
                    //return NotFound();
                    return Ok(new { Msg = "0", Reason = "No row affected!" });
                }
                else
                {
                    throw;
                }
            }
        }


        [AcceptVerbs("POST")]
        [Route("api/TmsMachineDocument/DeleteMachineDocument")]
        [ResponseType(typeof(TMS_Machine_Documents))]
        public IHttpActionResult DeleteMachineDocument(int id)
        {
            var disburse = _objMachineDocumentBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _objMachineDocumentBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsMobilityExists(int id)
        {
            return _objMachineDocumentBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}


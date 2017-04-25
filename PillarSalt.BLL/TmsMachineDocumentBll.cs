using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineDocumentBll
    {
        private TmsMachineDocumentRepository _repository;
        public TmsMachineDocumentBll()
        {
            _repository = new TmsMachineDocumentRepository();
        }

        public IEnumerable<TMS_Machine_Documents> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(TMS_Machine_Documents tmsMachineDocuments)
        {
            return _repository.Update(tmsMachineDocuments);
        }

        public IEnumerable<TMS_Machine_Documents> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Machine_Documents tmsMachineDocuments)
        {
            return _repository.Insert(tmsMachineDocuments);
        }
    }
}

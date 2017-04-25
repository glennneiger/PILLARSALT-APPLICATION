using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsWorkVerificationBll
    {
        private TmsWorkVerificationRepository _repository;

        public TmsWorkVerificationBll()
        {
            _repository = new TmsWorkVerificationRepository();
        }

        public IEnumerable<TMS_WorkVerification> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_WorkVerification> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_WorkVerification workVerification)
        {
            return _repository.Insert(workVerification);
        }

        public int Update(TMS_WorkVerification workVerification)
        {
            return _repository.Update(workVerification);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

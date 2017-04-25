using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{

    public class TmsAssignCommissionBll
    {
        private TmsAssignCommissionRepository _repository;

        public TmsAssignCommissionBll()
        {
            _repository = new TmsAssignCommissionRepository();
        }


        public IEnumerable<TMS_Assign_Commission> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Assign_Commission> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Assign_Commission tmsAdvertBilling)
        {
            return _repository.Insert(tmsAdvertBilling);
        }

        public int Update(TMS_Assign_Commission advertBilling)
        {
            return _repository.Update(advertBilling);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }


}

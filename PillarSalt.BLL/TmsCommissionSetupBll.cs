using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsCommissionSetupBll
    {
        private TmsCommissionSetupRepository _repository;
        public TmsCommissionSetupBll()
        {
            _repository = new TmsCommissionSetupRepository();
        }

        public IEnumerable<TMS_Commission_Setup> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Commission_Setup tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_Commission_Setup tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

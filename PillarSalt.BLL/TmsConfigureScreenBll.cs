using System.Collections.Generic;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsConfigureScreenBll
    {
        private TmsConfigureScreenRepository _repository;
        public TmsConfigureScreenBll()
        {
            _repository = new TmsConfigureScreenRepository();
        }

        public IEnumerable<TMS_ConfigureScreen> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_ConfigureScreen tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_ConfigureScreen tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }

}

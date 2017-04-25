using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsRetailerSetupBll
    {
        private TmsRetailerSetupRepository _repository;
        public TmsRetailerSetupBll()
        {
            _repository = new TmsRetailerSetupRepository();
        }

        public IEnumerable<TMS_Retailer_Setup> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Retailer_Setup tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_Retailer_Setup tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

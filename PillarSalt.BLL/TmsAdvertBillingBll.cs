using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAdvertBillingBll
    {
        private TmsAdvertBillingRepository _repository;

        public TmsAdvertBillingBll()
        {
            _repository = new TmsAdvertBillingRepository();
        }


        public IEnumerable<TMS_AdvertBilling> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_AdvertBilling> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_AdvertBilling tmsAdvertBilling)
        {
            return _repository.Insert(tmsAdvertBilling);
        }

        public int Update(TMS_AdvertBilling advertBilling)
        {
            return _repository.Update(advertBilling);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

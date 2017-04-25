using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAdvertiseCashBll
    {
        private TmsAdvertiseCashRepository _repository;
        public TmsAdvertiseCashBll()
        {
            _repository = new TmsAdvertiseCashRepository();
        }
        public IEnumerable<TMS_Advertise_Cash> GetAll()
        {
            return _repository.GetAll();
        }

       public TMS_Advertise_Cash GetById(int id)
        {
            return _repository.GetById(id);
        }



        public int Insert(TMS_Advertise_Cash tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);

        }

        public int Delete(int id)
        {
            int d = _repository.Delete(id);
            return d;
        }


        public int Update(TMS_Advertise_Cash tmsAdvertiseCash)
        {
            int d = _repository.Update(tmsAdvertiseCash);
            return d;
        }
    }
}

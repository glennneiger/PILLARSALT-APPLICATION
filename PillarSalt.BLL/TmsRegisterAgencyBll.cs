using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsRegisterAgencyBll
    {
        private TmsRegisterAgencyRepository _repository;
        public TmsRegisterAgencyBll()
        {
            _repository = new TmsRegisterAgencyRepository();
        }

        public IEnumerable<TMS_RegisterAgency> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_RegisterAgency tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_RegisterAgency tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

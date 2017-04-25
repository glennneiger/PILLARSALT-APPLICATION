using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsRegisterBankhBll
    {
        private TmsRegisterBankRepository _repository;
        public TmsRegisterBankhBll()
        {
            _repository = new TmsRegisterBankRepository();
        }

        public IEnumerable<TMS_Register_Bank> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Register_Bank tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_Register_Bank tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

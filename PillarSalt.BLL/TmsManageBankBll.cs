using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsManageBankBll
    {
        private TmsManageBankRepository _repository;
        public TmsManageBankBll()
        {
            _repository = new TmsManageBankRepository();
        }

        public IEnumerable<TMS_Manage_Bank> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Manage_Bank tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_Manage_Bank tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

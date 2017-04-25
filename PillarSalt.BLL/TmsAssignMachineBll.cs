using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAssignMachineBll
    {
        private TmsAssignMachineRepository _repository;
        public TmsAssignMachineBll()
        {
            _repository = new TmsAssignMachineRepository();
        }

        public IEnumerable<TMS_AssignMachine> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_AssignMachine tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_AssignMachine tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

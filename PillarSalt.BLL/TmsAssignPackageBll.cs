using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAssignPackageBll
    {
        private TmsAssignPackageRepository _repository;
        public TmsAssignPackageBll()
        {
            _repository = new TmsAssignPackageRepository();
        }

        public IEnumerable<TMS_AssignPackage> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_AssignPackage tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_AssignPackage tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

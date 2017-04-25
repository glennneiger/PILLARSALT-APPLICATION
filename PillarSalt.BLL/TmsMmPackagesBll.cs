using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMmPackagesBll
    {
        private TmsMmPackagesRepository _repository;
        public TmsMmPackagesBll()
        {
            _repository = new TmsMmPackagesRepository();
        }

        public IEnumerable<TMS_MMPackages> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_MMPackages tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_MMPackages tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

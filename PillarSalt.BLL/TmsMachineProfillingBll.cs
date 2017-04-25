using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineProfillingBll
    {
        private TmsMachineProfillingRepository _repository;
        public TmsMachineProfillingBll()
        {
            _repository = new TmsMachineProfillingRepository();
        }

        public IEnumerable<Asset_FixedAssets> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Asset_FixedAssets tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(Asset_FixedAssets tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

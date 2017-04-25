using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsResourceAllocationBll
    {
        private TmsResourceAllocationRepository _repository;
        public TmsResourceAllocationBll()
        {
            _repository = new TmsResourceAllocationRepository();
        }

        public IEnumerable<TMS_ResourceAllocation> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_ResourceAllocation tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_ResourceAllocation tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

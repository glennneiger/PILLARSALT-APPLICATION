using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsJobOrderBll
    {
        private TmsJobOrderRepository _repository;

        public TmsJobOrderBll()
        {
            _repository = new TmsJobOrderRepository();
        }

        public IEnumerable<TMS_JobOrder> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_JobOrder> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_JobOrder jobOrder)
        {
            return _repository.Insert(jobOrder);
        }

        public int Update(TMS_JobOrder jobOrder)
        {
            return _repository.Update(jobOrder);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

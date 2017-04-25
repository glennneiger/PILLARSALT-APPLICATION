using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAdvertSchedulingBll
    {
        private TmsAdvertSchedulingRepository _repository;
        public TmsAdvertSchedulingBll()
        {
            _repository = new TmsAdvertSchedulingRepository();
        }

        public IEnumerable<TMS_AdvertScheduling> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_AdvertScheduling tmsDisbursment)
        {
            return _repository.Insert(tmsDisbursment);
        }

        public int Update(TMS_AdvertScheduling tmsDisbursment)
        {
            return _repository.Update(tmsDisbursment);
        }

        public IEnumerable<TMS_AdvertScheduling> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

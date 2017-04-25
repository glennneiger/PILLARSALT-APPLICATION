using System.Collections.Generic;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMobilityBll
    {
        private TmsMobilityRepository _repository;

        public TmsMobilityBll()
        {
            _repository = new TmsMobilityRepository();
        }

        public IEnumerable<TMS_Mobility> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(TMS_Mobility obj)
        {
            int d = _repository.Update(obj);
            return d;
        }

        public TMS_Mobility GetById(int id)
        {
            return _repository.GetById(id);

        }

        public int Delete(int id)
        {
            int d = _repository.Delete(id);
            return d;
        }

        public int Insert(TMS_Mobility tmsMobility)
        {
            return _repository.Insert(tmsMobility);
        }
    }
}

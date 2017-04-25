using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineLocationBll
    {
        private TmsMachineLocationRepository _repository;
        public TmsMachineLocationBll()
        {
            _repository = new TmsMachineLocationRepository();
        }

        public IEnumerable<TMS_Machine_Locations> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(TMS_Machine_Locations tmsMachineLocations)
        {
            return _repository.Update(tmsMachineLocations);
        }

        public IEnumerable<TMS_Machine_Locations> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Machine_Locations tmsMachineLocations)
        {
            return _repository.Insert(tmsMachineLocations);
        }
    }
}

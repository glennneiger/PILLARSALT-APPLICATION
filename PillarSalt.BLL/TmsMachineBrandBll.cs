using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineBrandBll
    {
        private TmsMachineBrandRepository _repository;
        public TmsMachineBrandBll()
        {
            _repository = new TmsMachineBrandRepository();
        }

        public IEnumerable<TMS_Machine_Brand> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(TMS_Machine_Brand tmsMachineLocations)
        {
            return _repository.Update(tmsMachineLocations);
        }

        public IEnumerable<TMS_Machine_Brand> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Machine_Brand tmsMachineBrand)
        {
           return _repository.Insert(tmsMachineBrand);
        }
    }
}

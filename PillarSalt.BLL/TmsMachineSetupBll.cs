using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{

    public class TmsMachineSetupBll
    {
        private TmsMachineSetupRepository _repository;
        public TmsMachineSetupBll()
        {
            _repository = new TmsMachineSetupRepository();
        }

        public IEnumerable<TMS_Machine_Setup> GetAll()
        {
            return _repository.GetAll();
        }

       public TMS_Machine_Setup GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Insert(TMS_Machine_Setup obj)
        {
            return _repository.Insert(obj);

        }

        public int Delete(int id)
        {
            int d = _repository.Delete(id);
            return d;
        }

        public int Update(TMS_Machine_Setup obj)
        {
            int d = _repository.Update(obj);
            return d;
        }

    }
}

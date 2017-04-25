using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsSwitchSetupBll
    {
        private TmsSwitchSetupRepository _repository;

        public TmsSwitchSetupBll()
        {
            _repository = new TmsSwitchSetupRepository();
        }

        public IEnumerable<TMS_SwitchSetup> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_SwitchSetup> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_SwitchSetup switchSetup)
        {
            return _repository.Insert(switchSetup);
        }

        public int Update(TMS_SwitchSetup switchSetup)
        {
            return _repository.Update(switchSetup);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsSectorSettingsBll
    {
        private TmsSectorSettingsRepository _repository;

        public TmsSectorSettingsBll()
        {
            _repository = new TmsSectorSettingsRepository();
        }

        public IEnumerable<TMS_SectorSettings> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_SectorSettings> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_SectorSettings sectorSettings)
        {
            return _repository.Insert(sectorSettings);
        }

        public int Update(TMS_SectorSettings sectorSettings)
        {
            return _repository.Update(sectorSettings);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

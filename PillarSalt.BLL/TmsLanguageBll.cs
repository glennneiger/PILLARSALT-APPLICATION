using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace DASHBOARD.API.Controllers
{
    public class TmsLanguageBll
    {
        private TmsLanguageRepository _repository;

        public TmsLanguageBll()
        {
            _repository = new TmsLanguageRepository();
        }

        public IEnumerable<TMS_Language> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Language> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }


        public int Insert(TMS_Language language)
        {
            return _repository.Insert(language);
        }

        public int Update(TMS_Language language)
        {
            return _repository.Update(language);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
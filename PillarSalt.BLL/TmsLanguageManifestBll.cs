using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsLanguageManifestBll
    {
        private TmsLanguageManifestRepository _repository;

        public TmsLanguageManifestBll()
        {
            _repository = new TmsLanguageManifestRepository();
        }

        public IEnumerable<TMS_LanguageManifest> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_LanguageManifest> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }


        public int Insert(TMS_LanguageManifest language)
        {
            return _repository.Insert(language);
        }

        public int Update(TMS_LanguageManifest language)
        {
            return _repository.Update(language);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
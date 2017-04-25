using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsLanguageResourcesBll
    {
        private TmsLanguageResourcesReposirory _reposirory;
        public TmsLanguageResourcesBll()
        {
            _reposirory = new TmsLanguageResourcesReposirory();
        }

        public IEnumerable<TMS_LanguageResources> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<TMS_LanguageResources> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_LanguageResources language)
        {
            return _reposirory.Insert(language);
        }

        public int Update(TMS_LanguageResources language)
        {
            return _reposirory.Update(language);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsDependencyBll
    {
        private TmsDependencyRepository _repository;

        public TmsDependencyBll()
        {
            _repository = new TmsDependencyRepository();
        }

        public IEnumerable<TMS_Dependency> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Dependency> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Dependency dependency)
        {
            return _repository.Insert(dependency);
        }

        public int Update(TMS_Dependency dependency)
        {
            return _repository.Update(dependency);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

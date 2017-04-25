using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineBagsBll
    {
        private TmsMachineBagsReposirory _reposirory;

        public TmsMachineBagsBll()
        {
            _reposirory = new TmsMachineBagsReposirory();
        }
        public IEnumerable<TMS_MachineBags> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<TMS_MachineBags> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_MachineBags mb)
        {
            return _reposirory.Insert(mb);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }

        public int Update(TMS_MachineBags mb)
        {
            return _reposirory.Update(mb);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DASHBOARD.API.Controllers;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsDepositBagBll
    {
        private TmsDepositBagReposirory _reposirory;
        public TmsDepositBagBll()
        {
            _reposirory = new TmsDepositBagReposirory();
        }

        public IEnumerable<TMS_DepositeBag> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<TMS_DepositeBag> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_DepositeBag bag)
        {
            return _reposirory.Insert(bag);
        }

        public int Update(TMS_DepositeBag bag)
        {
            return _reposirory.Update(bag);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}
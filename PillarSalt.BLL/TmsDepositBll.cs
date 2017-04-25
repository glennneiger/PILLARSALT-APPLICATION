using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsDepositBll
    {
        private TmsDepositReposirory _reposirory;

        public TmsDepositBll()
        {
            _reposirory = new TmsDepositReposirory();
        }

        public IEnumerable<TMS_Deposit> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<TMS_Deposit> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Deposit accountsDepositDetails)
        {
            return _reposirory.Insert(accountsDepositDetails);
        }

        public int Update(TMS_Deposit accountsDepositDetails)
        {
            return _reposirory.Update(accountsDepositDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }


    }
}

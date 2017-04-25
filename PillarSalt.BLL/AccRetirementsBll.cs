using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccRetirementsBll
    {
        private AccRetirementsReposirory _reposirory;

        public AccRetirementsBll()
        {
            _reposirory = new AccRetirementsReposirory();
        }

        public IEnumerable<Acc_Retirements> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<Acc_Retirements> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(Acc_Retirements accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(Acc_Retirements accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

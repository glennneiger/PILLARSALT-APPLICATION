using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccBankBll
    {
        private AccBankReposirory _reposirory;

        public AccBankBll()
        {
            _reposirory = new AccBankReposirory();
        }

        public IEnumerable<ACCBank> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<ACCBank> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(ACCBank accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(ACCBank accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

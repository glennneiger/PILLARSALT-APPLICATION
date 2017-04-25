using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccBankMappingBll
    {
        private AccBankMappingBllReposirory _reposirory;

        public AccBankMappingBll()
        {
            _reposirory = new AccBankMappingBllReposirory();
        }

        public IEnumerable<Acc_BankMapping> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<Acc_BankMapping> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(Acc_BankMapping accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(Acc_BankMapping accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

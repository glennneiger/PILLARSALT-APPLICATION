using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccAccountsBankDetailsBll
    {
        private AccountsBankDetailsReposirory _reposirory;

        public AccAccountsBankDetailsBll()
        {
            _reposirory = new AccountsBankDetailsReposirory();
        }

        public IEnumerable<Acc_Accounts_BankDetails> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<Acc_Accounts_BankDetails> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(Acc_Accounts_BankDetails accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(Acc_Accounts_BankDetails accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

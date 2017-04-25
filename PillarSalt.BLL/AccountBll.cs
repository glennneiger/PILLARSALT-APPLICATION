using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccountBll
    {
        private AccountRepository _repository;
        public AccountBll()
        {
            _repository = new AccountRepository();
        }

        public IEnumerable<Account> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Account> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.SerialAcc.Equals(id));
        }

        public int Insert(Account accountsBankDetails)
        {
            return _repository.Insert(accountsBankDetails);
        }

        public int Update(Account accountsBankDetails)
        {
            return _repository.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

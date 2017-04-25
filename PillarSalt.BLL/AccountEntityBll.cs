using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccountEntityBll
    {
        private AccountEntityRepository _repository;

        public AccountEntityBll()
        {
            _repository = new AccountEntityRepository();
        }

        public IEnumerable<AccountEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<AccountEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Insert(AccountEntity accountEntity)
        {
            return _repository.Insert(accountEntity);
        }

        public int Update(AccountEntity accountEntity)
        {
            return _repository.Update(accountEntity);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

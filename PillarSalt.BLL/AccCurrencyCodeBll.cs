using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccCurrencyCodeBll
    {
        private AccCurrencyCodeReposirory _reposirory;

        public AccCurrencyCodeBll()
        {
            _reposirory = new AccCurrencyCodeReposirory();
        }

        public IEnumerable<Acc_CurrencyCode> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<Acc_CurrencyCode> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(Acc_CurrencyCode accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(Acc_CurrencyCode accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

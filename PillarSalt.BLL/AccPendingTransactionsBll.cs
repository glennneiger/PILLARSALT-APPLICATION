using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccPendingTransactionsBll
    {
        private AccPendingTransactionsReposirory _reposirory;

        public AccPendingTransactionsBll()
        {
            _reposirory = new AccPendingTransactionsReposirory();
        }

        public IEnumerable<Acc_Pending_Transactions> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<Acc_Pending_Transactions> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(Acc_Pending_Transactions accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(Acc_Pending_Transactions accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

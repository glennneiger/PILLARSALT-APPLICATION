using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsTransactionDetailsBll
    {
        private TmsTransactionDetailsRepository _repository;
        public TmsTransactionDetailsBll()
        {
            _repository = new TmsTransactionDetailsRepository();
        }

        public IEnumerable<TMS_TransactionDetails> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_TransactionDetails tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_TransactionDetails tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

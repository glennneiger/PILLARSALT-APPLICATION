using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsBulkCashBll
    {
        private TmsBulkCashRepository _repository;
        public TmsBulkCashBll()
        {
            _repository = new TmsBulkCashRepository();
        }

        public IEnumerable<TMS_BulkCash> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_BulkCash tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_BulkCash tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsCustomerStatementBll
    {
        private TmsCustomerStatementRepository _repository;
        public TmsCustomerStatementBll()
        {
            _repository = new TmsCustomerStatementRepository();
        }

        public IEnumerable<TMS_Customer_Statement> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Customer_Statement tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_Customer_Statement tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

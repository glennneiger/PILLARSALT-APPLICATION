using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsQueryPaymentBll
    {
        private TmsQueryPaymentRepository _repository;

        public TmsQueryPaymentBll()
        {
            _repository = new TmsQueryPaymentRepository();
        }

        public IEnumerable<TMS_QueryPayment> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_QueryPayment> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_QueryPayment queryPayment)
        {
            return _repository.Insert(queryPayment);
        }

        public int Update(TMS_QueryPayment queryPayment)
        {
            return _repository.Update(queryPayment);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

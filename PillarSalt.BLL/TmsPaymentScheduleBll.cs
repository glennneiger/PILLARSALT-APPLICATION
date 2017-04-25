using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsPaymentScheduleBll
    {
        private TmsPaymentScheduleRepository _repository;

        public TmsPaymentScheduleBll()
        {
            _repository = new TmsPaymentScheduleRepository();
        }

        public IEnumerable<TMS_PaymentSchedule> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_PaymentSchedule> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_PaymentSchedule paymentSchedule)
        {
            return _repository.Insert(paymentSchedule);
        }

        public int Update(TMS_PaymentSchedule paymentSchedule)
        {
            return _repository.Update(paymentSchedule);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }

}

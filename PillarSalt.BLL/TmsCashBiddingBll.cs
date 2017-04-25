using System.Collections.Generic;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsCashBiddingBll
    {
        private readonly TmsCashBiddingRepository _repository;
        public TmsCashBiddingBll()
        {
            _repository = new TmsCashBiddingRepository();
        }

        public IEnumerable<TMS_CashBidding> GetAll()
        {
            return _repository.GetAll();
        }

        public TMS_CashBidding GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Update(TMS_CashBidding tmsDisbursment)
        {
            return _repository.Update(tmsDisbursment);

        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_CashBidding tmsCashBidding)
        {
            return _repository.Insert(tmsCashBidding);
        }
    }
}

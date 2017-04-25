using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAuctionSettingBll
    {
        private TmsAuctionSettingRepository _repository;
        public TmsAuctionSettingBll()
        {
            _repository = new TmsAuctionSettingRepository();
        }

        public IEnumerable<TMS_Auction_Settings> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public TMS_Auction_Settings GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Update(TMS_Auction_Settings tmsAuctionSettings)
        {
            return _repository.Update(tmsAuctionSettings);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Auction_Settings tmsDisbursment)
        {
            return _repository.Insert(tmsDisbursment);
        }
    }
}

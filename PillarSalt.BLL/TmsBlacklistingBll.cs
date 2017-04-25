using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsBlacklistingBll
    {
        private TmsBlacklistingRepository _repository;
        public TmsBlacklistingBll()
        {
            _repository = new TmsBlacklistingRepository();
        }

        public IEnumerable<TMS_Blacklisting> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Blacklisting> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Blacklisting blacklisting)
        {
            return _repository.Insert(blacklisting);
        }

        public int Update(TMS_Blacklisting blacklisting)
        {
            return _repository.Update(blacklisting);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

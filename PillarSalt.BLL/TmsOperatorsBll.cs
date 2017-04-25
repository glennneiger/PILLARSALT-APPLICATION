using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsOperatorsBll
    {
        private TmsOperatorsRepository _repository;
        public TmsOperatorsBll()
        {
            _repository = new TmsOperatorsRepository();
        }

        public IEnumerable<TMS_Operators> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Operators tmsAdvertiseCash)
        {
            return _repository.Insert(tmsAdvertiseCash);
        }

        public int Update(TMS_Operators tmsAdvertiseCash)
        {
            return _repository.Update(tmsAdvertiseCash);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

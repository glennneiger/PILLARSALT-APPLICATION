using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsCashdamsBll
    {
        private TmsCashdamsRepository _repository;
        public TmsCashdamsBll()
        {
            _repository = new TmsCashdamsRepository();
        }

        public IEnumerable<TMS_Cashdams> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TMS_Cashdams cashdams)
        {
            return _repository.Insert(cashdams);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Update(TMS_Cashdams cashdams)
        {
            return _repository.Update(cashdams);
        }
    }
}

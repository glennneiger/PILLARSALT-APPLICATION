using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAccountSetupBll
    {
        private TmsAccountSetupRepository _repository;
        public TmsAccountSetupBll()
        {
            _repository = new TmsAccountSetupRepository();
        }


        public IEnumerable<TMS_Acct_Setup> GetAll()
        {
            return _repository.GetAll();
        }

        public List<TMS_Acct_Setup> GetAll2()
        {
            return (List<TMS_Acct_Setup>)_repository.GetAll();
        }

        public TMS_Acct_Setup GetById(int id)
        {
            return _repository.GetById(id);
        }



        public int Insert(TMS_Acct_Setup tmsAcctSetup)
        {
            return _repository.Insert(tmsAcctSetup);

        }

        public int Delete(int id)
        {
            int d = _repository.Delete(id);
            return d;
        }


        public int Update(TMS_Acct_Setup tmsAcctSetup)
        {
            int d = _repository.Update(tmsAcctSetup);
            return d;
        }
    }
}

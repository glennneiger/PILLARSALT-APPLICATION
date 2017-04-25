using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class CrmContactBll
    {
        private CrmContactRepository _repository;
        public CrmContactBll()
        {
            _repository = new CrmContactRepository();
        }


        public IEnumerable<CRMContact> GetAll()
        {
            return _repository.GetAll();
        }

        public List<CRMContact> GetAll2()
        {
            return (List<CRMContact>) _repository.GetAll();
        }

        public CRMContact GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Insert(CRMContact obj)
        {
            return _repository.Insert(obj);

        }

        public int Delete(int id)
        {
            int d = _repository.Delete(id);
            return d;
        }

        public int Update(CRMContact obj)
        {
            int d = _repository.Update(obj);
            return d;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAdminCodeBll
    {
        private TmsAdminCodeRepository _repository;
        public TmsAdminCodeBll()
        {
            _repository = new TmsAdminCodeRepository();
        }

        public IEnumerable<TMS_AdminCode> GetAll()
        {
            return _repository.GetAll();

        }

        public int Insert(TMS_AdminCode adminCode)
        {
            return _repository.Insert(adminCode);
        }

        public int Update(TMS_AdminCode adminCode)
        {
            return _repository.Update(adminCode);
        }

        public IEnumerable<TMS_AdminCode> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsWarrantyStatusBll
    {
        private TmsWarrantyStatusRepository _repository;

        public TmsWarrantyStatusBll()
        {
            _repository = new TmsWarrantyStatusRepository();
        }

        public IEnumerable<TMS_WarrantyStatus> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_WarrantyStatus> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_WarrantyStatus warrantyStatus)
        {
            return _repository.Insert(warrantyStatus);
        }

        public int Update(TMS_WarrantyStatus warrantyStatus)
        {
            return _repository.Update(warrantyStatus);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

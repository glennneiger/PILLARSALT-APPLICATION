using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMaintenanceVoucherBll
    {
        private TmsMaintenanceVoucherRepository _repository;

        public TmsMaintenanceVoucherBll()
        {
            _repository = new TmsMaintenanceVoucherRepository();
        }

        public IEnumerable<TMS_MaintenanceVoucher> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_MaintenanceVoucher> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_MaintenanceVoucher maintenanceVoucher)
        {
            return _repository.Insert(maintenanceVoucher);
        }

        public int Update(TMS_MaintenanceVoucher maintenanceVoucher)
        {
            return _repository.Update(maintenanceVoucher);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

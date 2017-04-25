using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsAssignTechnicianBll
    {
        private TmsAssignTechnicianRepository _repository;

        public TmsAssignTechnicianBll()
        {
            _repository = new TmsAssignTechnicianRepository();
        }

        public IEnumerable<TMS_Assign_Technician> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Assign_Technician> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Assign_Technician assignTechnician)
        {
            return _repository.Insert(assignTechnician);
        }

        public int Update(TMS_Assign_Technician assignTechnician)
        {
            return _repository.Update(assignTechnician);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

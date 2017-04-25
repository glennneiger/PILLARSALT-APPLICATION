using System.Collections.Generic;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineStatusBll
    {
        private TmsMachineStatusRepository _repository;
        public TmsMachineStatusBll()
        {
            _repository = new TmsMachineStatusRepository();
        }

        public IEnumerable<TMS_Machine_Status> GetAll()
        {
            return _repository.GetAll();
        }

       public TMS_Machine_Status GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Insert(TMS_Machine_Status obj)
        {
            return _repository.Insert(obj);

        }

        public int Delete(int id)
        {
            int d = _repository.Delete(id);
            return d;
        }

        public int Update(TMS_Machine_Status obj)
        {
            int d = _repository.Update(obj);
            return d;
        }



    }
}

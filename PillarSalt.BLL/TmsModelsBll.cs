using System.Collections.Generic;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsModelsBll
    {
        private TmsModelsRepository _repository;
        public TmsModelsBll()
        {
            _repository = new TmsModelsRepository();
        }

        public IEnumerable<TMS_Models> GetAll()
        {
            return _repository.GetAll();
        }

        public TMS_Models GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Update(TMS_Models tmsModels)
        {
            return _repository.Update(tmsModels);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Models tmsModels)
        {
            return _repository.Insert(tmsModels);
        }
    }
}

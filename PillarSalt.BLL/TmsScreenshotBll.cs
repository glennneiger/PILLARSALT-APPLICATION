using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsScreenshotBll
    {
        private TmsScreenshotRepository _repository;

        public TmsScreenshotBll()
        {
            _repository = new TmsScreenshotRepository();
        }

        public IEnumerable<TMS_Screenshot> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Screenshot> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Screenshot screenshot)
        {
            return _repository.Insert(screenshot);
        }

        public int Update(TMS_Screenshot screenshot)
        {
            return _repository.Update(screenshot);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsSendCommandBll
    {
        private TmsSendCommandRepository _repository;

        public TmsSendCommandBll()
        {
            _repository = new TmsSendCommandRepository();
        }

        public IEnumerable<TMS_SendCommand> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_SendCommand> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_SendCommand sendCommand)
        {
            return _repository.Insert(sendCommand);
        }

        public int Update(TMS_SendCommand sendCommand)
        {
            return _repository.Update(sendCommand);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

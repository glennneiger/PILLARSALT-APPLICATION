using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineDisposalBll
    {
        private TmsMachineDisposalRepository _repository;
        public TmsMachineDisposalBll()
        {
            _repository = new TmsMachineDisposalRepository();
        }

        public IEnumerable<TMS_Machine_Disposal> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(TMS_Machine_Disposal tmsMachineDisposal)
        {
            return _repository.Update(tmsMachineDisposal);
        }

        public IEnumerable<TMS_Machine_Disposal> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Machine_Disposal tmsMachineDisposal)
        {
            return _repository.Insert(tmsMachineDisposal);
        }
    }
}

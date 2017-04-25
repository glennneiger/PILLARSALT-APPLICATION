using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsBankingSectorsBll
    {
        private TmsBankingSectorsRepository _repository;

        public TmsBankingSectorsBll()
        {
            _repository = new TmsBankingSectorsRepository();
        }

        public IEnumerable<TMS_Banks_Sectors> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TMS_Banks_Sectors> GetById(int id)
        {
            return _repository.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_Banks_Sectors bankingSectors)
        {
            return _repository.Insert(bankingSectors);
        }

        public int Update(TMS_Banks_Sectors bankingSectors)
        {
            return _repository.Update(bankingSectors);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }


}

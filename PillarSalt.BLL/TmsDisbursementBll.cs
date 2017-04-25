using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsDisbursementBll
    {
        private TmsDisbursementRepository _repository;
        public TmsDisbursementBll()
        {
            _repository = new TmsDisbursementRepository();
        }

        public IEnumerable<TMS_Disbursment> GetAll()
        {
            return _repository.GetAll();
        }

        public TMS_Disbursment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Update(TMS_Disbursment tmsDisbursment)
        {
          return  _repository.Update(tmsDisbursment);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Insert(TMS_Disbursment obj)
        {
            return _repository.Insert(obj);

        }
     
       
    }
}

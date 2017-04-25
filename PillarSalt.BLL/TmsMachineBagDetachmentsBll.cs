using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class TmsMachineBagDetachmentsBll
    {
        private TmsMachineBagDetachmentsRepository _reposirory;
        public TmsMachineBagDetachmentsBll()
        {
            _reposirory = new TmsMachineBagDetachmentsRepository();
        }

        public IEnumerable<TMS_MachineBagDetachment> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<TMS_MachineBagDetachment> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(TMS_MachineBagDetachment mbd)
        {
            return _reposirory.Insert(mbd);
        }

        public int Update(TMS_MachineBagDetachment mbd)
        {
            return _reposirory.Update(mbd);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}

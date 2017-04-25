﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarSalt.BOL;
using PillarSalt.DAL_REPO;

namespace PillarSalt.BLL
{
    public class AccountLogBll
    {
        private AccountLogReposirory _reposirory;

        public AccountLogBll()
        {
            _reposirory = new AccountLogReposirory();
        }

        public IEnumerable<AccountLog> GetAll()
        {
            return _reposirory.GetAll();
        }

        public IEnumerable<AccountLog> GetById(int id)
        {
            return _reposirory.GetAll().Where(i => i.Id.Equals(id));
        }

        public int Insert(AccountLog accountsBankDetails)
        {
            return _reposirory.Insert(accountsBankDetails);
        }

        public int Update(AccountLog accountsBankDetails)
        {
            return _reposirory.Update(accountsBankDetails);
        }

        public int Delete(int id)
        {
            return _reposirory.Delete(id);
        }
    }
}
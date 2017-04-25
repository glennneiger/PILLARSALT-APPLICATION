using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using PillarSalt.BOL;

namespace DASHBOARD.API.Models
{
    public class BankAccountViewModel
    {
        public IEnumerable<Acc_Accounts_BankDetails> AccAccountsBankDetails { get; set; }
        public IEnumerable<AccountEntity> AccountEntity { get; set; }
        public IEnumerable<ACCBank> AccBanks { get; set; }
        public IEnumerable<Acc_BankMapping> AccBankMapping { get; set; }
        public IEnumerable<Acc_CurrencyCode> AccCurrencyCodes { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Acc_Retirements> AccRetirements { get; set; }
        public IEnumerable<CustomerPayment> CustomerPayments { get; set; }
        public IEnumerable<Acc_Retirements> AccRetirementses { get; set; }
        public IEnumerable<Acc_Pending_Transactions> AccPendingTransactionses { get; set; }
        public IEnumerable<aspnet_Users> AspnetUserses { get; set; }

    }
}
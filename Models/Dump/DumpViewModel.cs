using EamonnCoyleATM.Models.ATM.Account;
using EamonnCoyleATM.Models.ATM.Client;
using EamonnCoyleATM.Models.ATM.Transaction;

namespace EamonnCoyleATM.Models.Dump
{
    public class DumpViewModel
    {
        public List<AccountModel> Accounts { get; set; }
        public List<ClientModel> Clients { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}

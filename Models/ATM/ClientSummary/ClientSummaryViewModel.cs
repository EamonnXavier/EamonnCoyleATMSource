using EamonnCoyleATM.Models.ATM.Account;
using EamonnCoyleATM.Models.ATM.Transaction;

namespace EamonnCoyleATM.Models.ATM.ClientSummary
{
    public class ClientSummaryViewModel
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string IDNumber { get; set; }
        public WithdrawalResponseModel WithdrawalResponse { get; set; }
        public List<AccountModel> Accounts { get; set; }
        /* Account properties:
        *  public int AccountID { get; set; }
        *  public int ClientID { get; set; }
        *  public string AccountNumber { get; set; }
        *  public string AccountType { get; set; }
        *  public string DateOpened { get; set; }
         */
        public List<TransactionModel> Transactions { get; set; }
        /* Transaction properties:
         * public int TransactionId { get; set; }
         * public int AccountId { get; set; }
         * public int Amount { get; set; }
         * public string Date { get; set; }
         */


    }
}

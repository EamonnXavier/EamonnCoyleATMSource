using EamonnCoyleATM.Models.ATM.Transaction;
using System.ComponentModel.DataAnnotations;

namespace EamonnCoyleATM.Models.ATM.Account
{
    public class AccountModel
    {
        [Key]
        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string DateOpened { get; set; }
    }
}

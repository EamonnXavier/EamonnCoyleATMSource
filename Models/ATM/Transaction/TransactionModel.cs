using System.ComponentModel.DataAnnotations;

namespace EamonnCoyleATM.Models.ATM.Transaction
{
    public class TransactionModel
    {
        [Key]
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
    }
}

using EamonnCoyleATM.Models.ATM.Transaction;

namespace EamonnCoyleATM.Services.Transaction
{
    public interface ITransactionService
    {
        ITransactionService WithAccountId(int accountId);
        ITransactionService WithTransaction(TransactionModel transactionId);
        Task<bool> InsertAsync();
        Task<List<TransactionModel>> GetAsync();

    }
}

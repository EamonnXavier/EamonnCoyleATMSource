using EamonnCoyleATM.Data;
using EamonnCoyleATM.Models.ATM.Transaction;
using Microsoft.EntityFrameworkCore;

namespace EamonnCoyleATM.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        //db context 
        private readonly ApplicationDbContext _context;

        //fields
        private int _accountId;
        private TransactionModel _transaction;

        //constructor
        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ITransactionService WithAccountId(int accountId)
        {
            _accountId = accountId;
            return this;
        }
        public ITransactionService WithTransaction(TransactionModel transaction)
        {
            _transaction = transaction;
            return this;
        }

        public async Task<List<TransactionModel>> GetAsync()
        {
            //accountId only
            if (_accountId > 0)
            {
                var result = await _context.Transaction.FromSqlRaw("SELECT * FROM `Transaction` WHERE `AccountID` = {0}", _accountId).IgnoreQueryFilters().ToListAsync();
                Clean();
                return result;
            }
            //no parameters
            else
            {
                var result = await _context.Transaction.ToListAsync();
                Clean();
                return result;
            }           
        }

        public async Task<bool> InsertAsync()
        {
            //insert transaction
            _context.Transaction.Add(_transaction);
            await _context.SaveChangesAsync();
            Clean();
            return true;
        }

        private void Clean()
        {
            _accountId = 0;
        }

    }
}

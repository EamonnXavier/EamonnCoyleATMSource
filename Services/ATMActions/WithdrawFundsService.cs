using EamonnCoyleATM.Models.ATM;
using EamonnCoyleATM.Models.ATM.Transaction;
using EamonnCoyleATM.Services.Account;
using EamonnCoyleATM.Services.Transaction;
using System.Globalization;

namespace EamonnCoyleATM.Services.ATMActions
{
    public class WithdrawFundsService : IWithdrawFundsService
    {
        //fields
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private int _accountId;
        private int _amount;

        //ctor
        public WithdrawFundsService(
            IAccountService accountService,
            ITransactionService transactionService
            )
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }

        public IWithdrawFundsService WithAccountId(int accountId)
        {
            _accountId = accountId;
            return this;
        }
        
        public IWithdrawFundsService WithAmount(int amount)
        {
            _amount = amount;
            return this;
        }

        public async Task<WithdrawalResponseModel> Withdraw()
        {
            var response = new WithdrawalResponseModel();
            //get account
            var account = await _accountService.WithAccountId(_accountId).GetAsync();
            if (account==null)
            {
                response.Success = false;
                response.Message = "Account not found";
                return response;
            }

            //get all transactions for the account
            var transactions = _transactionService.WithAccountId(_accountId).GetAsync().Result;
            var balance = transactions.Sum(x => x.Amount);
            
            
            if (_amount < 0)
            {
                response.Success = false;
                response.Message = "Amount must be greater than zero";
                return response;
            }

            //withdraw funds
            var newTransaction = new TransactionModel
            {
                AccountID = _accountId,
                Amount = -1*_amount,
                Date = DateTime.Today.ToString("dd-MMM", CultureInfo.CreateSpecificCulture("en-US")),
            };

            //insert transaction
            var insertion = await _transactionService.WithTransaction(newTransaction).InsertAsync();

            if (insertion)
            {
                //return new balance
                response.Success = true;
                response.ClientId = account[0].ClientID;
                response.Message = $"Withdrawal successful. New balance is {balance - _amount}";
                return response;
            }
            else
            {
                response.Success = false;
                response.Message = $"Withdrawal failed. Balance remains {balance}";
                return response;
            }

        }
        private void Clean()
        {
            _accountId = 0;
            _amount = 0;
        }
    }
}

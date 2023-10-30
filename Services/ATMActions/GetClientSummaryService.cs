using EamonnCoyleATM.Models.ATM.ClientSummary;
using EamonnCoyleATM.Models.ATM.Transaction;
using EamonnCoyleATM.Services.Account;
using EamonnCoyleATM.Services.Client;
using EamonnCoyleATM.Services.Transaction;

namespace EamonnCoyleATM.Services.ATMActions
{
    public class GetClientSummaryService : IGetClientSummaryService
    {
        private IClientService _clientService;
        private IAccountService _accountService;
        private ITransactionService _transactionService;

        //fields
        private int _clientId;

        public GetClientSummaryService(
            IClientService clientService,
            IAccountService accountService,
            ITransactionService transactionService)
        {
            _clientService = clientService;
            _accountService = accountService;
            _transactionService = transactionService;        
        }
        public IGetClientSummaryService WithClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }
        public async Task<ClientSummaryViewModel> GetAsync()
        {
            //get the client from the db
            var client = await _clientService.WithClientId(_clientId).GetAsync();
            //get the accounts for this client
            var accounts = await _accountService.WithClientId(_clientId).GetAsync();
            //get the transactions for this client
            var transactions = new List<TransactionModel>();

            foreach (var account in accounts)
            {
                var accTrans = await _transactionService.WithAccountId(account.AccountID).GetAsync();
                transactions.AddRange(accTrans);
            }
            //create the view model
            var clientSummaryViewModel = new ClientSummaryViewModel
            {
                ClientID = client[0].ClientID,
                Name = client[0].Name,
                Surname = client[0].Surname,
                IDNumber = client[0].IDNumber,
                Password = client[0].Password,
                Accounts = accounts,
                Transactions = transactions
            };

            Clean();

            return clientSummaryViewModel;


        }
        private void Clean()
        {
            _clientId = 0;
        }

        
    }
}

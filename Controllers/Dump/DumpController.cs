using EamonnCoyleATM.Models.ATM.Account;
using EamonnCoyleATM.Models.ATM.Client;
using EamonnCoyleATM.Models.ATM.Transaction;
using EamonnCoyleATM.Models.Dump;
using EamonnCoyleATM.Services.Account;
using EamonnCoyleATM.Services.Client;
using EamonnCoyleATM.Services.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace EamonnCoyleATM.Controllers.Dump
{
    public class DumpController : Controller
    {
        //services
        private IAccountService _accountService;
        private IClientService _clientService;
        private ITransactionService _transactionService;

        public DumpController(
            IAccountService accountService,
            IClientService clientService,
            ITransactionService transactionService
        ) 
        { 
            //services
            _accountService = accountService;
            _clientService = clientService;
            _transactionService = transactionService;        
        }


        //index
        public ActionResult Index()
        {
            var accounts = _accountService.GetAsync().Result;
            var clients = _clientService.GetAsync().Result;
            var transactions = _transactionService.GetAsync().Result;

            var viewModel = new DumpViewModel
            {
                Accounts = accounts,
                Clients = clients,
                Transactions = transactions                
            };
            return View("DumpView", viewModel);
        }
    }
}

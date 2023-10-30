using EamonnCoyleATM.Services.ATMActions;
using Microsoft.AspNetCore.Mvc;

namespace EamonnCoyleATM.Controllers
{
    public class WithdrawController : Controller
    {
        //services
        private IWithdrawFundsService _withdrawService;
        //ctor
        public WithdrawController(IWithdrawFundsService withdrawService)
        {
            _withdrawService = withdrawService;
        }
        //get clientId from routevalues
        public ActionResult Index(int accountId)
        {
            //set the account id in the viewbag
            ViewBag.AccountId = accountId;

            return PartialView("_WithdrawModal"); 
        }

        //post 
        [HttpPost]
        public ActionResult Withdraw(int accountId, int amount)
        {
            var withdrawal = _withdrawService.WithAccountId(accountId).WithAmount(amount).Withdraw().Result;
            var success=withdrawal.Success;
            var message=withdrawal.Message;
            var clientId=withdrawal.ClientId;

            return RedirectToAction("ReturnAfterWithdraw", "ClientSummary", new {clientId=clientId, success=success, message=message});

        }
    }
}

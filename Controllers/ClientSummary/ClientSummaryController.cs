using EamonnCoyleATM.Models.ATM;
using EamonnCoyleATM.Services.ATMActions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace EamonnCoyleATM.Controllers.ClientSummary
{
    public class ClientSummaryController : Controller
    {
        //services
        private IGetClientSummaryService _getClientSummaryService;
        //ctor
        public ClientSummaryController(IGetClientSummaryService getClientSummaryService)
        {
            _getClientSummaryService = getClientSummaryService;
        }
        //get clientId from routevalues
        public ActionResult Index(int clientId)
        {
            var clientSummary = _getClientSummaryService.WithClientId(clientId).GetAsync().Result;

            //return the view with this model
            return View("ClientSummaryView", clientSummary);
        }
        public ActionResult ReturnAfterWithdraw(int clientId, bool success, string message)
        {
            var clientSummary = _getClientSummaryService.WithClientId(clientId).GetAsync().Result;
            clientSummary.WithdrawalResponse = new WithdrawalResponseModel
            {
                Success=success,
                Message=message
            };

            //return the view with this model
            return View("ClientSummaryView", clientSummary);
        }


    }
}

using EamonnCoyleATM.Models.ATM.ClientSummary;

namespace EamonnCoyleATM.Services.ATMActions
{
    public interface IGetClientSummaryService
    {
        IGetClientSummaryService WithClientId(int clientId);
        Task<ClientSummaryViewModel> GetAsync();
    }
}

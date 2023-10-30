using EamonnCoyleATM.Models.ATM.Client;

namespace EamonnCoyleATM.Services.Client
{
    public interface IClientService
    {
        IClientService WithClientId(int clientId);
        IClientService WithPassword(string password);
        IClientService WithUsername(string username);

        Task<List<ClientModel>> GetAsync();
    }
}

using EamonnCoyleATM.Models.ATM.Account;

namespace EamonnCoyleATM.Services.Account
{
    public interface IAccountService
    {
        IAccountService WithClientId(int clientId);
        IAccountService WithAccountId(int accountId);
        Task<List<AccountModel>> GetAsync();
    }
}

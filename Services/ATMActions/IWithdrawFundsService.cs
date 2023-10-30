using EamonnCoyleATM.Models.ATM;

namespace EamonnCoyleATM.Services.ATMActions
{
    public interface IWithdrawFundsService
    {
        IWithdrawFundsService WithAccountId(int accountId);
        IWithdrawFundsService WithAmount(int amount);

        Task<WithdrawalResponseModel> Withdraw();
    }
}

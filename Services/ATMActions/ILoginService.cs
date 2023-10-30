namespace EamonnCoyleATM.Services.ATMActions
{
    public interface ILoginService
    {
        ILoginService WithUsername(string username);
        ILoginService WithPassword(string password);
        Task<int> LoginAsync();

    }
}

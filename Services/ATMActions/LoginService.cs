using EamonnCoyleATM.Services.Client;

namespace EamonnCoyleATM.Services.ATMActions
{
    public class LoginService : ILoginService
    {
        //services
        private IClientService _clientService;

        //fields
        private string _username;
        private string _password;
        //ctor
        public LoginService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<int> LoginAsync()
        {
            if (Validate())
            {
                //get from client table where username and pass match
                var client = await _clientService.WithUsername(_username).WithPassword(_password).GetAsync();
                //if client exists
                if (client.Count > 0)
                {
                    Clean();
                    return client[0].ClientID;
                }
                else
                {
                    Clean();
                    return 0;
                }
            }
            else
            {
                Clean();
                return 0;
            }
        }

        public ILoginService WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public ILoginService WithUsername(string username)
        {
            _username = username;
            return this;
        }

        //private methods
        private void Clean()
        {
            _username = String.Empty;
            _password = String.Empty;
        }
        //validation for username and pass
        private bool Validate()
        {
            //would validate and check username and pass here
            return true;
        }
    }
}

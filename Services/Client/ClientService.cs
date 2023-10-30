using EamonnCoyleATM.Data;
using EamonnCoyleATM.Models.ATM.Client;
using Microsoft.EntityFrameworkCore;

namespace EamonnCoyleATM.Services.Client
{
    public class ClientService : IClientService
    {
        //db context
        private readonly ApplicationDbContext _context;

        //fields
        private int _clientId;
        private string _username;
        private string _password;

        //ctor
        public ClientService(ApplicationDbContext context)
        {
               _context = context;
        }

        //extension
        public IClientService WithClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }
        public IClientService WithUsername(string username)
        {
            _username = username;
            return this;
        }
        public IClientService WithPassword(string password)
        {
            _password = password;
            return this;
        }

        //public methods
        public async Task<List<ClientModel>> GetAsync()
        {
            //clientId only
            if (_clientId > 0)
            {
                var result = await _context.Client.FromSqlRaw("SELECT * FROM Client WHERE ClientID = {0}", _clientId).ToListAsync();
                Clean();
                return result;
            }
            //username and password
            else if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password))
            {
                var result = await _context.Client.FromSqlRaw("SELECT * FROM Client WHERE Name = {0} AND Password = {1}", _username, _password).ToListAsync();
                Clean();
                return result;
            }
            //no parameters
            else
            {
                var result = await _context.Client.ToListAsync();
                Clean();
                return result;
            }
        }

        //private methods
        private void Clean()
        {
            _clientId = 0;
            _username = string.Empty;
            _password = string.Empty;

        }

    }
}

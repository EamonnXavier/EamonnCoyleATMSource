using System.Collections.Generic;
using System.Threading.Tasks;
using EamonnCoyleATM.Data;
using EamonnCoyleATM.Models.ATM.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EamonnCoyleATM.Services.Account
{

    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private int _clientId;
        private int _accountId;
        public AccountService(ApplicationDbContext context)
        {            
            _context = context;
        }

        #region Extensions
        public IAccountService WithClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }
        public IAccountService WithAccountId(int accountId)
        {
            _accountId = accountId;
            return this;
        }
        #endregion

        #region Public Methods
        public async Task<List<AccountModel>> GetAsync()
        {
            //client id only
            if (_clientId > 0)
            {
                var result = await _context.Account.FromSqlRaw("SELECT * FROM Account WHERE ClientID = {0}", _clientId).ToListAsync();
                Clean();
                return result;
            }
            //account id only
            else if (_accountId > 0)
            {
                var result = await _context.Account.FromSqlRaw("SELECT * FROM Account WHERE AccountID = {0}", _accountId).ToListAsync();
                Clean();
                return result;
            }
            else
            {
                var result = await _context.Account.ToListAsync();
                Clean();
                return result;
            }
        }
        #endregion

        #region Private Methods
        private void Clean()
        {
            _clientId = 0;
            _accountId = 0;
        }
        #endregion

    }
}

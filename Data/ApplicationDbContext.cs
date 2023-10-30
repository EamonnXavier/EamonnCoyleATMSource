using EamonnCoyleATM.Models.ATM.Account;
using EamonnCoyleATM.Models.ATM.Client;
using EamonnCoyleATM.Models.ATM.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace EamonnCoyleATM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<AccountModel> Account { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<TransactionModel> Transaction { get; set; }
    }
}

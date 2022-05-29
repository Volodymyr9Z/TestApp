using Microsoft.EntityFrameworkCore;
using TestApp.DataAccess.Abstraction;
using TestApp.Domain.Entities;

namespace TestApp.DataAccess.Repositories
{
    public class AccountRepository : BaseRepository<Account> , IAccountRepository
    {
        public AccountRepository(TestAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Account> GetByNameAsync(string name)
        {
            var account = await dbContext.Accounts
                .Include(a => a.Contacts)
                .Include(a=>a.Incident)
                .Where(a => a.Name == name)
                .FirstOrDefaultAsync();
            return account;
        }
    }
}

using TestApp.Domain.Entities;

namespace TestApp.DataAccess.Abstraction
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetByNameAsync(string name);
    }
}

using TestApp.Domain.Entities;

namespace TestApp.DataAccess.Abstraction
{
    public interface IContactRepository : IBaseRepository<Contact> 
    {
        Task<Contact> GetByEmailAsync(string email);
    }
}

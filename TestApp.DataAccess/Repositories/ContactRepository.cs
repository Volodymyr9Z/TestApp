using Microsoft.EntityFrameworkCore;
using TestApp.DataAccess.Abstraction;
using TestApp.Domain.Entities;

namespace TestApp.DataAccess.Repositories
{
    public class ContactRepository : BaseRepository<Contact> , IContactRepository
    {
        public ContactRepository(TestAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Contact> GetByEmailAsync(string email)
        {
            var contact = await dbContext.Contacts
                .Include(c => c.Account)
                .Where(c => c.Email == email)
                .FirstOrDefaultAsync();
            return contact;
        }
    }
}

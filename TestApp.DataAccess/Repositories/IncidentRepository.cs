using TestApp.DataAccess.Abstraction;
using TestApp.Domain.Entities;

namespace TestApp.DataAccess.Repositories
{
    public class IncidentRepository : BaseRepository<Incident> , IIncidentRepository
    {
        public IncidentRepository(TestAppDbContext dbContext) : base(dbContext)
        {
                   
        }
    }
}

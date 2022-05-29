using TestApp.Domain.Entities;

namespace TestApp.Domain.DTO_s.AccountDTO
{
    public class ResultDTO
    {
        public string AccountName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string IncidentId { get; set; }
    }
}

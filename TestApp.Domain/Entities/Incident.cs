
namespace TestApp.Domain.Entities
{
    public class Incident
    {
        public Incident()
        {
            Accounts = new List<Account>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}

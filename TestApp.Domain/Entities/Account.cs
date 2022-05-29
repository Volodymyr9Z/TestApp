using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestApp.Domain.Entities
{
    public class Account
    {
        public Account()
        {
            Contacts = new List<Contact>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Incident Incident { get; set; }
        
    }
}

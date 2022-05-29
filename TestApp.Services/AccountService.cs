using AutoMapper;
using TestApp.DataAccess.Abstraction;
using TestApp.Domain.DTO_s.AccountDTO;
using TestApp.Domain.Entities;
using TestApp.Services.Abstraction;

namespace TestApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;
        private readonly IContactRepository contactRepository;
        private readonly IIncidentRepository incidentRepository;
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IContactRepository contactRepository, IIncidentRepository incidentRepository)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
            this.contactRepository = contactRepository;
            this.incidentRepository = incidentRepository;
        }

        

        public async Task<ResultDTO> CheckAccountAsync(CheckAccountDTO checkAccountDTO)
        {
            var currentContact = await contactRepository.GetByEmailAsync(checkAccountDTO.Email);
            if (currentContact == null)
            {
                if (await accountRepository.GetByNameAsync(checkAccountDTO.Name) == null)
                {
                    var contact = mapper.Map<Contact>(checkAccountDTO);
                    var newAccount = mapper.Map<Account>(checkAccountDTO);
                    newAccount.Contacts.Add(contact);
                    var newIncident = mapper.Map<Incident>(checkAccountDTO);
                    newIncident.Name = RandomString(10);
                    newIncident.Accounts.Add(newAccount);
                    await incidentRepository.AddAsync(newIncident);                  
                    //return mapper.Map<ResultDTO>(contact);
                    throw new InvalidOperationException($"Account wasn't found but we created it so try again");
                }
                else
                {
                    var contact = mapper.Map<Contact>(checkAccountDTO);
                    var account = await accountRepository.GetByNameAsync(checkAccountDTO.Name);
                    account.Contacts.Add(contact);
                    await contactRepository.AddAsync(contact);
                    await accountRepository.UpdateAsync(account);
                    return mapper.Map<ResultDTO>(contact);
                }
            }
            else
            {                            
                if (currentContact.Account == await accountRepository.GetByNameAsync(checkAccountDTO.Name))
                {
                    currentContact.FirstName = checkAccountDTO.FirstName;
                    currentContact.LastName = checkAccountDTO.LastName;
                    await contactRepository.UpdateAsync(currentContact); 
                }
                else throw new InvalidOperationException($"This contact  has account , for changing try enter correct account name");
            }
                return mapper.Map<ResultDTO>(currentContact);         
        }
    }
}

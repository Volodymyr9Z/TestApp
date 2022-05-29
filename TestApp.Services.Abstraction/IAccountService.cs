using TestApp.Domain.DTO_s.AccountDTO;

namespace TestApp.Services.Abstraction
{
    public interface IAccountService
    {
        
        Task<ResultDTO> CheckAccountAsync(CheckAccountDTO checkAccountDTO);
    }
}

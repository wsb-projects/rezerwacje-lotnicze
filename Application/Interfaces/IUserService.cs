using rezerwacje_lotnicze.Domain.Entities.User;
using rezerwacje_lotnicze.Infrastructure;

namespace rezerwacje_lotnicze.Application.Interfaces;

public interface IUserService
{
    Task<ServiceResult<string>> RegisterAsync(RegisterModel model);
    Task<ServiceResult<string>> LoginAsync(LoginModel model);
}

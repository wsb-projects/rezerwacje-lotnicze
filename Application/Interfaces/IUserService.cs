using rezerwacje_lotnicze.Domain.Entities.User;
using rezerwacje_lotnicze.Infrastructure;

namespace rezerwacje_lotnicze.Application.Interfaces;

public interface IUserService
{
    Task<ServiceResult> Register(RegisterModel model);
    Task<ServiceResult> Login(LoginModel model);
}

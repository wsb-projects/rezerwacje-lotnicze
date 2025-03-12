using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Application.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(User user);
}
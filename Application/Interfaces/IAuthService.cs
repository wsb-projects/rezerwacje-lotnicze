namespace rezerwacje_lotnicze.Application.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(string username);
}
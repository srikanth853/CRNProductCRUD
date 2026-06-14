using Application.DTOs;

namespace Application.Interfaces;

public interface IAuthService
{
    AuthResponse Login(LoginRequest request);
}
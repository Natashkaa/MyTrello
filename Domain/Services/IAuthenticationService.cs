using System.Threading.Tasks;
using MyTrello.Domain.Services.Communication;

namespace MyTrello.Domain.Services
{
    public interface IAuthenticationService
    {
         Task<UserResponse> AuthenticateAsync(string email, string password);
    }
}
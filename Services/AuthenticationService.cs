using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MyTrello.Domain.Models;
using MyTrello.Domain.Repositories;
using MyTrello.Domain.Services;
using MyTrello.Domain.Services.Communication;
using MyTrello.Extensions;
using MyTrello.Helpers;

namespace MyTrello.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;
        public AuthenticationService(IOptions<AppSettings> settings,
                                     IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.appSettings = settings.Value;
        }
        public async Task<UserResponse> AuthenticateAsync(string email, string password)
        {
            User user = (await userRepository.GetAllAsync())
                            .SingleOrDefault(u => u.User_Email == email
                                                        &&
                                             u.User_Password == password);
            if(user == null)
                return new UserResponse("Invalid email or password");
            try
            {
                user.GenerateTokenString(appSettings.Secret, appSettings.TokenExpires);
                user.User_Password = null;
                return new UserResponse(user);
            }
            catch(Exception ex)
            {
                return new UserResponse($"Something happend when authenticating user: {ex.Message}");
            }
        }
    }
}
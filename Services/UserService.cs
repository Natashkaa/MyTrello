using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrello.Domain.Models;
using MyTrello.Domain.Repositories;
using MyTrello.Domain.Services;
using MyTrello.Domain.Services.Communication;

namespace MyTrello.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService( IUserRepository userRepository,
                            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public Task<UserResponse> AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserResponse> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public Task<UserResponse> UpdateAsync(int id, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
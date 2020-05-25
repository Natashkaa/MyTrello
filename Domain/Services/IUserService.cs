using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrello.Domain.Models;
using MyTrello.Domain.Services.Communication;

namespace MyTrello.Domain.Services
{
    public interface IUserService
    {
         Task<IEnumerable<User>> GetAllAsync();
         Task<UserResponse> AddAsync(User user);
         Task<UserResponse> UpdateAsync(int id, User user);
         Task<UserResponse> DeleteAsync(int id);
    }
}
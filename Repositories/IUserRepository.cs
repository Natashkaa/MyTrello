using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrello.Domain.Models;
namespace MyTrello.Repositories
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetAllAsync();
         Task<User> GetByIdAsync(int id);
         System.Threading.Tasks.Task AddAsync(User newUser);
         void Update(User user);
         void Remove(User user);
    }
}
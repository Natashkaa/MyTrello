using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyTrello.Domain.Models;

namespace MyTrello.Domain.Repositories
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetAllAsync();
         Task<User> GetByIdAsync(int id);
         System.Threading.Tasks.Task AddAsync(User newUser);
         void Update(User user);
         void Remove(User user);
         Task<User> UpdatePhoto(int user_id, IFormFile uploadedFile);
    }
}
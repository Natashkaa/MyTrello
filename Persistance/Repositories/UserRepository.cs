using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTrello.Domain.Models;
using MyTrello.Domain.Repositories;
using MyTrello.Persistance.Contexts;

namespace MyTrello.Persistance.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context){}

        public async System.Threading.Tasks.Task AddAsync(User newUser)
        {
            await context.Users.AddAsync(newUser);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public void Remove(User user)
        {
            context.Users.Remove(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }
    }
}
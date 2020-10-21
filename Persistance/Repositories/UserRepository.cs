using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public async Task<User> UpdatePhoto(int user_id, IFormFile uploadedFile)
        {
            User user = await GetByIdAsync(user_id);
            if (uploadedFile != null)
            {
                // путь к папке Files
                string mainPath = "Files/";
                string nameForPhoto = user.User_FirstName + user.UserId + "." + uploadedFile.ContentType.Substring(uploadedFile.ContentType.IndexOf("/")+1);
                // сохраняем файл в папку Files
                using (var fileStream = new FileStream(mainPath + nameForPhoto, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                
                user.User_PhotoPath = nameForPhoto;
                Update(user);
            }
            return user;
        }
    }
}
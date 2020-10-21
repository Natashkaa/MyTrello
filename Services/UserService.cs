using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<UserResponse> AddAsync(User user)
        {
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch(Exception ex)
            {
                return new UserResponse($"Error: something happend while adding user: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if(user == null)
                return new UserResponse($"Can not find user with id {id}");

            try
            {
                userRepository.Remove(user);
                await unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch(Exception ex)
            {
                return new UserResponse($"Error: something happend while deleting user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if(user == null)
            {
                return new UserResponse($"Can not find user with id {id}");
            }
            return new UserResponse(user);
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existUser = await userRepository.GetByIdAsync(id);
            if(existUser == null)
                return new UserResponse($"Can not find user with id {id}");
            existUser.User_FirstName = user.User_FirstName;
            existUser.User_LastName = user.User_LastName;
            existUser.User_Email = user.User_Email;
            try
            {
                userRepository.Update(existUser);
                await unitOfWork.CompleteAsync();
                return new UserResponse(existUser);
            }
            catch(Exception ex)
            {
                return new UserResponse($"User update error: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdatePhoto(int id, IFormFile uploadedFile)
        {
            try
            {
                User user = await userRepository.UpdatePhoto(id, uploadedFile);
                await unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch(Exception ex)
            {
                return new UserResponse($"Error: something happend while updating photo: {ex.Message}");
            }
        }
    }
}
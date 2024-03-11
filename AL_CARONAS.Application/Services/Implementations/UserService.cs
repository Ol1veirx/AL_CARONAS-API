using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using AL_CARONAS.Infraestructure.Persistence;
using AL_CARONAS.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AL_CARONAS.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();          
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _repository.GetUserByIdAsync(userId);
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            var user = await _repository.GetByEmailAsync(email);

            if (user == null) return false;

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            return await _repository.CreateUserAsync(newUser);            
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _repository.DeleteUserAsync(userId);
        }
    }
}

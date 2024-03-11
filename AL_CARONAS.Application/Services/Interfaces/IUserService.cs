using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;

namespace AL_CARONAS.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User newUser);
/*      Task UpdateUserAsync(int userId, User user);*/        
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> AuthenticateUserAsync(string email, string password);    
    }
}

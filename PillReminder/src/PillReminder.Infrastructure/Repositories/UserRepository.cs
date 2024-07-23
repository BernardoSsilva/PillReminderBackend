

using Microsoft.EntityFrameworkCore;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using System.Reflection.Metadata;

namespace PillReminder.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly PillReminderDbAccess _dbAccess;

        public UserRepository(PillReminderDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }


        // register user
        public async Task<bool> RegisterNewUser(UserEntity user)
        {
            await _dbAccess.AddAsync(user);
            return true;
        }

        // delete user
        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _dbAccess.Users.FirstOrDefaultAsync(user => user.Id == userId);
            if (user is null)
            {
                return false;
            }
            _dbAccess.Users.Remove(user);
            return true;
        }

        //Find user list

        public async Task<List<UserEntity>> FindAllUsers()
        {
            var UserList = await _dbAccess.Users.AsNoTracking().ToListAsync();

            return UserList;
        }

        // find user by id

        public async Task<UserEntity?> FindUserById(string id)
        {
            var user = await _dbAccess.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);

            return user;
        }



        public void UpdateUser(UserEntity NewUserData)
        {
            _dbAccess.Users.Update(NewUserData);
        }

        public async Task<bool> UpdateUserPassword(string userId, string password)
        {
            var user = await _dbAccess.Users.FirstOrDefaultAsync((user) => user.Id == userId);
            if(user is null)
            {
                return false;
            }
            user.Password = password;
            
            _dbAccess.Users.Update(user);
            return true;

        }
    }
}
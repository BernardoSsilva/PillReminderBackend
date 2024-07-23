using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IUserRepository
    {

        Task<bool> RegisterNewUser(UserEntity user);
        Task<UserEntity?> FindUserById(string id);
        Task<List<UserEntity>> FindAllUsers();

        void UpdateUser( UserEntity NewUserData);

        Task<bool> UpdateUserPassword(string userId, string password);
        Task<bool> DeleteUser(string userId);

    }
}

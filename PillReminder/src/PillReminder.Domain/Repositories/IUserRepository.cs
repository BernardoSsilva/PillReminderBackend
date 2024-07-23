using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IUserRepository
    {

        Task RegisterNewUser(UserEntity user);
        Task<UserEntity> FindUserById(string id);
        Task<List<UserEntity>> FindAllUsers();

        Task UpdateUser(string userId, UserEntity NewUserData);

        Task UpdateUserPassword(string userId, string password);
        Task DeleteUser(string userId);

    }
}

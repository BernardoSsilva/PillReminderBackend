using PillReminder.Communication.users.Requests;
using PillReminder.Communication.users.Responses;

namespace PillReminderApplication.UseCases.User.Post.Interfaces
{
    public interface IAuthenticateUserUseCase
    {
        Task<UserAuthenticationResponseJson> Execute(UserAuthenticationRequestJson request);
    }
}

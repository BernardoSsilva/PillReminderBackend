using PillReminder.Comunication.users.Requests;
using PillReminder.Comunication.users.Responses;

namespace PillReminderApplication.UseCases.User.Post.Interfaces
{
    public interface IRegisterUserUseCase
    {
        Task<UserShortJsonResponse> Execute(UserJsonRequest user);
    }
}

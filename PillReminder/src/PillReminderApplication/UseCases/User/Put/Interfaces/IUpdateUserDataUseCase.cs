using PillReminder.Comunication.users.Requests;

namespace PillReminderApplication.UseCases.User.Put.Interfaces
{
    public interface IUpdateUserDataUseCase
    {
        Task Execute(string userId, UserJsonRequest requestData);
    }
}

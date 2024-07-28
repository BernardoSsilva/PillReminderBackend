using PillReminder.Comunication.users.Responses;

namespace PillReminderApplication.UseCases.User.Get.Interfaces
{
    public interface IGetUserByIdUseCase
    {
        Task<DetailedUserJsonResponse> Execute(string userId);
    }
}

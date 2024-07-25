using PillReminder.Comunication.users.Responses;
using PillReminder.Domain.entities;

namespace PillReminderApplication.UseCases.User.Get.Interfaces
{
    public interface IListUsersUseCase
    {

        Task<MultipleUserJsonResposne> Execute(); 
    }
}

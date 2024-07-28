namespace PillReminderApplication.UseCases.User.Delete.Interfaces
{
    public interface IDeleteUserUseCase
    {
        Task Execute(string userId);
    }
}

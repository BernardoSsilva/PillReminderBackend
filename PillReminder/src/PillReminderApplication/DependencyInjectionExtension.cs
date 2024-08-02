using Microsoft.Extensions.DependencyInjection;
using PillReminderApplication.AutoMapper;
using PillReminderApplication.UseCases.Remedy.Delete;
using PillReminderApplication.UseCases.Remedy.Delete.interfaces;
using PillReminderApplication.UseCases.Remedy.Get;
using PillReminderApplication.UseCases.Remedy.Get.interfaces;
using PillReminderApplication.UseCases.Remedy.Post;
using PillReminderApplication.UseCases.Remedy.Post.Interface;
using PillReminderApplication.UseCases.Remedy.Put;
using PillReminderApplication.UseCases.Remedy.Put.Interfaces;
using PillReminderApplication.UseCases.User.Delete;
using PillReminderApplication.UseCases.User.Delete.Interfaces;
using PillReminderApplication.UseCases.User.Get;
using PillReminderApplication.UseCases.User.Get.Interfaces;
using PillReminderApplication.UseCases.User.Post;
using PillReminderApplication.UseCases.User.Post.Interfaces;
using PillReminderApplication.UseCases.User.Put;
using PillReminderApplication.UseCases.User.Put.Interfaces;

namespace PillReminderApplication
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {

            AddAutoMapper(service);
            AddUseCases(service);
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            service.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            service.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
            service.AddScoped<IListUsersUseCase, ListUsersUseCase>();
            service.AddScoped<IUpdateUserDataUseCase, UpdateUserDataUseCase>();
            service.AddScoped<IAuthenticateUserUseCase, AuthenticateUserUseCase>();
            service.AddScoped<ICreateNewRemedyUseCase, CreateNewRemedyUseCase>();
            service.AddScoped<IFindAllRemediesByUserUseCase, FindAllRemediesByUserUseCase>();
            service.AddScoped<IFindRemedyByIdUseCase, FindRemedyByIdUseCase>();
            service.AddScoped<IUpdateRemedyUseCase, UpdateRemedyUseCase>();
            service.AddScoped<IDeleteRemedyUseCase, DeleteRemedyUseCase>();

        }
    }
}

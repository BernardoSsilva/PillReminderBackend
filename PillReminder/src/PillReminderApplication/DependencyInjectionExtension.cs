using Microsoft.Extensions.DependencyInjection;
using PillReminderApplication.AutoMapper;

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
        }
    }
}

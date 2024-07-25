using Microsoft.Extensions.DependencyInjection;
using PillReminder.Domain;
using PillReminder.Domain.Repositories;
using PillReminder.Infrastructure.DataAccsess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillReminder.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddRepositories(service);
        }

        private static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IRemedyRepository, RemedyRepository>();
            service.AddScoped<IImagesRepository, ImagesRepository>();
        }
    }
}

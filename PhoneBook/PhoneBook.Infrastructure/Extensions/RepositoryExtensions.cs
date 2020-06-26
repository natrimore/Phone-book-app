using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Infrastructure.Repositories;

namespace PhoneBook.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}

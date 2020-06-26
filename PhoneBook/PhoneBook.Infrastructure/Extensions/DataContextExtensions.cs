using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Infrastructure.DataContext;
using System;

namespace PhoneBook.Infrastructure.Extensions
{
    public static class DataContextExtensions
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            string connectionString;
            using(var provider = services.BuildServiceProvider())
            {
                var configuration = provider.GetService<IConfiguration>();
                connectionString = configuration["ConnectionString"];
            }

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("sql server connection is not found");

            services.AddEntityFrameworkNpgsql().AddDbContext<PhoneBookDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            
            using (var provider = services.BuildServiceProvider())
            {
                var context = provider.GetService<PhoneBookDbContext>();
                context.Database.Migrate();
            }

            return services;
        }

        
    }
}

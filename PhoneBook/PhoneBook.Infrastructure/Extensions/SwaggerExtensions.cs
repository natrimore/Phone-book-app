using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructure.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(conf =>
            {
                conf.SwaggerDoc(
                    name: "v1",
                    new OpenApiInfo()
                    {
                        Title = "PhoneBook.Api",
                        Version = "0.0.1",
                        //TermsOfService = "None",
                        //Contact = new OpenApiContact()
                        //{
                            
                        //}
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerApp(this IApplicationBuilder builder)
        {
            builder.UseSwagger();

            builder.UseSwaggerUI(conf =>
            {
                conf.SwaggerEndpoint("v1/swagger.json", "PhoneBook.Api");
            });

            return builder;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBook.Infrastructure.Middlewares
{
    /// <summary>
    /// Exception handler middleware
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate request;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            request = next;
        }

        public Task Invoke(HttpContext context) => this.InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.request(context);
            }
            catch (Exception exception)
            {
                var httpStatusCode = ConfigException(exception);

                context.Response.StatusCode = httpStatusCode;
                context.Response.ContentType = JsonContentType;

                var response = new { code = httpStatusCode, message = exception.Message };
                var payload = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(payload);
            }
        }


        private static int ConfigException(Exception exception)
        {
            int httpStatusCode;

            switch (exception)
            {
                case var _ when exception is ValidationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            return httpStatusCode;
        }
    }
}

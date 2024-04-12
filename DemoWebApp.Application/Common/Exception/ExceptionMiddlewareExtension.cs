using DemoWebApp.Domain.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLog;
using System.Net;

namespace DemoWebApp.Domain.Exception
{
    public static class ExceptionMiddlewareExtension
    {

        /// <summary>
        /// Simply configuration
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, Logger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorResult()
                        {
                            ErrorCode = Enum.ErrorCode.ExceptionError,
                            MessageError = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}

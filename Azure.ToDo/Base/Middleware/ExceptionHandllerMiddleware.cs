using Newtonsoft.Json;
using System.Net;
using FluentValidation;
using Azure.ToDo.Repository.Interface;
using Azure.ToDo.Infrastructure.Exception;

namespace Azure.ToDo.Base.Middleware
{
    public class ExceptionHandllerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandllerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IExceptionLogger exceptionLogger)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                await ManageException(context, exceptionLogger, exception);
            }
        }

        private async Task ManageException(HttpContext context, IExceptionLogger exceptionLogger, Exception ex)
        {
            switch (ex)
            {
                case ValidationException validationException:
                    {
                        await ConfigureResponse(context, HttpStatusCode.BadRequest, validationException.Message);
                        break;
                    }
                case ManagedException managedException:
                    {
                        await ConfigureResponse(context, HttpStatusCode.BadRequest, managedException.Message);
                        break;
                    }
                case NotFoundException notFoundException:
                    {
                        await ConfigureResponse(context, HttpStatusCode.NotFound, notFoundException.Message);
                        break;
                    }
                default:
                    {
                        await ConfigureResponse(context, HttpStatusCode.InternalServerError, "متاسفانه خطای سیستمی رخ داده است، در صورت لزوم با پشتیبانی تماس حاصل نمایید");
                        await exceptionLogger.SetLog(ex.Message, ex.StackTrace);
                    }
                    break;
            }
        }

        private static async Task ConfigureResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(
                new FailedResponseMessage(message).ToString());
        }

        public class FailedResponseMessage
        {
            public FailedResponseMessage(string message)
            {
                this.message = message;
            }
            public string message { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PlayersWebAPI.Core.Exceptions;
using PlayersWebAPI.Models.Common;
using System;
using System.Data.SqlClient;
using System.Net;

namespace PlayersWebAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        readonly ILogger logger;
        public ExceptionFilter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<ExceptionFilter>();
        }

        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException e:
                    logger.LogCritical($"NotFoundException : <{e.Code}> {e.Message}", e, e.Code.ToString());
                    context.Result = new NotFoundObjectResult(new Error
                    {
                        Code = $"404-{(int)e.Code:000}",
                        Message = e.Message
                    });
                    break;

                case UnvalidException e:
                    logger.LogCritical($"UnvalidException : <{e.Code}> {e.Message}", e, e.Code.ToString());
                    context.Result = new BadRequestObjectResult(new Error
                    {
                        Code = $"400-{(int)e.Code:000}",
                        Message = e.Message
                    });
                    break;

                case InternalErrorException e:
                    logger.LogCritical($"InternalErrorException : <{e.Code}> {e.Message}", e);
                    context.Result = new ObjectResult(new Error
                    {
                        Code = $"500-{(int)e.Code:000}",
                        Message = $"{Enum.GetName(typeof(InternalErrorCode), e.Code)} Error {e.Message}"
                    })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;

                case SqlException e:
                    logger.LogCritical($"[SQL] {e.Procedure} at line {e.LineNumber} : {e.Message}", e);
                    context.Result = new ObjectResult(new Error
                    {
                        Code = $"500-XXX"
                    })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;

                case UnauthorizedAccessException e:
                    logger.LogCritical(e, $"Exception {e.Message}", e);
                    context.Result = new ObjectResult(new Error
                    {
                        Code = $"401-XXX",
                        Message = e.Message
                    })
                    {
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    };
                    break;

                case Exception e:
                    logger.LogCritical(e, $"Exception {e.Message}", e);
                    context.Result = new ObjectResult(new Error
                    {
                        Code = $"500-XXX",
                        Message = e.Message
                    })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;

                default:
                    break;
            }
        }
    }
}

﻿using DocManager.Application.Shared.Wrappers;
using System.Net;
using System.Text.Json;
using static DocManager.Application.Shared.Constants.ApplicationConstants;

namespace DocManager.Api.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = CONTENT_TYPE;

            var responseModel = new Response<string>()
            {
                IsSucess = false,
                Message = exception?.Message
            };

            switch (exception)
            {
                case Application.Exceptions.ApiException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case Application.Exceptions.ValidationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}

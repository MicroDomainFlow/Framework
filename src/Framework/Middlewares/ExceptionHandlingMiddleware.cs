using FluentResults;

using FluentValidation;

using MDF.Framework.Extensions.Results;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace MDF.Framework.Middlewares;
public class ExceptionHandlingMiddleware
{
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		Next = next;
		_logger = logger;
	}

	protected RequestDelegate Next { get; }

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await Next(context);
		}
		catch (ValidationException ex)
		{
			await HandleValidationExceptionAsync(context, ex);
		}
		catch (Exception ex)
		{
			var methodName = ex.TargetSite.Name; // نام متد مرتبط با استثنا را بدست آورید
												 //-------------------------------------------------
			var stackTrace = new StackTrace(ex, true);
			var frame = stackTrace.GetFrame(0); // یکی از فریم‌های تمیزه را بدست آورید
			var methodName2 = frame.GetMethod().Name; // نام متد مرتبط با فریم را بدست آورید
			await HandleExceptionAsync(context, ex);
		}
	}

	private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
	{
		var code = HttpStatusCode.BadRequest;

		context.Response.StatusCode = (int)code;
		context.Response.ContentType = "application/json";

		var result = new Result();
		foreach (var error in exception.Errors)
		{
			result.WithError(error.ErrorMessage);
		}

		await WriteResultAsync(context, result);
	}

	private async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var code = HttpStatusCode.InternalServerError;

		context.Response.StatusCode = (int)code;
		context.Response.ContentType = "application/json";

		var result = new Result();
		result.WithError("Internal Server Error!");

		_logger.LogCritical(exception, exception.Message);

		await WriteResultAsync(context, result);
	}

	private async Task WriteResultAsync(HttpContext context, Result result)
	{
		var options = new JsonSerializerOptions
		{
			IncludeFields = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		};

		string resultString = JsonSerializer.Serialize(result.ConvertToCustomResult(), options);

		await context.Response.WriteAsync(resultString);
	}
}



public static class ExceptionHandlingMiddlewareExtensionMethod
{
	public static IApplicationBuilder UseGlobalExceptionResultHandler(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<ExceptionHandlingMiddleware>();
	}
}

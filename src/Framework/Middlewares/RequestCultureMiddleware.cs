using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System.Globalization;

namespace MDF.Middlewares;

/// <summary>
/// Middleware for setting the request culture based on the "culture" query parameter.
/// </summary>
public class RequestCultureMiddleware
{
	private readonly RequestDelegate _next;

	/// <summary>
	/// Initializes a new instance of the <see cref="RequestCultureMiddleware"/> class.
	/// </summary>
	/// <param name="next">The next middleware in the pipeline.</param>
	public RequestCultureMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	/// <summary>
	/// Invokes the middleware.
	/// </summary>
	/// <param name="context">The HTTP context.</param>
	/// <returns>A task that represents the asynchronous middleware operation.</returns>
	public async Task InvokeAsync(HttpContext context)
	{
		var cultureQuery = context.Request.Query["culture"];
		if (!string.IsNullOrWhiteSpace(cultureQuery))
		{
			var culture = new CultureInfo(cultureQuery);

			CultureInfo.CurrentCulture = culture;
			CultureInfo.CurrentUICulture = culture;
		}

		// Call the next delegate/middleware in the pipeline.
		await _next(context);
	}
}

/// <summary>
/// Extension methods for registering the <see cref="RequestCultureMiddleware"/> in the application pipeline.
/// </summary>
public static class RequestCultureMiddlewareExtensions
{
	/// <summary>
	/// Adds the <see cref="RequestCultureMiddleware"/> to the application pipeline.
	/// </summary>
	/// <param name="builder">The <see cref="IApplicationBuilder"/> instance.</param>
	/// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
	public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<RequestCultureMiddleware>();
	}
}

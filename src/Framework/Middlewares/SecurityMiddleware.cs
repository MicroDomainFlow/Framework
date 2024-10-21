using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MDF.Middlewares;
/// <summary>
/// Verify user rights and role whether is correct.
/// </summary>
public class SecurityMiddleware
{
	private readonly RequestDelegate _next;
	public SecurityMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task Invoke(HttpContext context)
	{
		// Check authentication
		if (!context.User.Identity.IsAuthenticated)
		{
			context.Response.Redirect("/account/login");
			return;
		}
		// Check authorization for admin page
		if (context.Request.Path.Value.StartsWith("/admin") && !context.User.IsInRole("Admin"))
		{
			context.Response.StatusCode = 403;
			return;
		}
		// Validate business rules
		if (!IsValidRequest(context.Request))
		{
			context.Response.StatusCode = 400;
			return;
		}
		await _next(context);
	}
	private bool IsValidRequest(HttpRequest request)
	{
		//TODO Check headers, params, business rules etc.
		return true;
	}
}
public static class SecurityMiddlewareExtensions
{
	public static IApplicationBuilder UseSecurityMiddleware(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<SecurityMiddleware>();
	}
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MDF.Framework.Middlewares;
public class RateLimitMiddleware
{
	private readonly RequestDelegate _next;
	public RateLimitMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	private const int PerMinuteLimit = 10;
	private static Dictionary<string, int> _requests = new Dictionary<string, int>();

	public async Task Invoke(HttpContext context)
	{
		var clientIp = context.Connection.RemoteIpAddress.ToString();
		// Increment counter for client
		if (_requests.ContainsKey(clientIp))
		{
			_requests[clientIp]++;
		}
		else
		{
			_requests.Add(clientIp, 1);
		}
		// Check if over limit
		if (_requests[clientIp] > PerMinuteLimit)
		{
			context.Response.StatusCode = 429; // Too many requests
			return;
		}
		await _next.Invoke(context);
		// Remove counter after request is complete
		_requests.Remove(clientIp);
	}
}
public static class RateLimitMiddlewareExtensions
{
	public static IApplicationBuilder UseRateLimitMiddleware(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<RateLimitMiddleware>();
	}
}
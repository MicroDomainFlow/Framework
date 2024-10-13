using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System.Globalization;

namespace Framework.Middlewares;
/// <summary>
/// Set culture, localization, or time zones based on request attributes.
/// </summary>
public class LocalizationMiddleware
{
	private readonly RequestDelegate _next;
	public LocalizationMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task Invoke(HttpContext context)
	{
		var userLanguage = context.Request.Headers["Accept-Language"].FirstOrDefault();

		// Set culture from header
		CultureInfo culture;
		if (!string.IsNullOrEmpty(userLanguage))
		{
			culture = new CultureInfo(userLanguage);
		}
		else
		{
			culture = new CultureInfo("fa-IR");
		}
		CultureInfo.CurrentCulture = culture;
		CultureInfo.CurrentUICulture = culture;
		// Set timezone
		var timezone = context.Request.Headers["TimeZone"].FirstOrDefault();
		if (!string.IsNullOrEmpty(timezone))
		{
			TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);
			var timeOffset = DateTimeOffset.Now.ToOffset(timeZone.BaseUtcOffset);
			TimeZoneInfo.Local.GetUtcOffset(timeOffset);

		}
		await _next(context);
	}
}
public static class LocalizationMiddlewareExtensions
{
	public static IApplicationBuilder UseLocalizationMiddleware(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<LocalizationMiddleware>();
	}
}
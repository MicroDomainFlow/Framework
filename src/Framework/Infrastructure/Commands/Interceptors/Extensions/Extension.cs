using Microsoft.EntityFrameworkCore;

namespace MDF.Infrastructure.Commands.Interceptors.Extensions;
/// <summary>
/// Provides extension methods for configuring interceptors in DbContextOptionsBuilder.
/// </summary>
public static class Extension
{
	/// <summary>
	/// Adds the common shadow properties interceptor to the DbContextOptionsBuilder.
	/// </summary>
	/// <param name="optionsBuilder">The DbContextOptionsBuilder.</param>
	/// <returns>The DbContextOptionsBuilder.</returns>
	public static DbContextOptionsBuilder UseCommonShadowPropertiesInterceptor(this DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.AddInterceptors(new AddCommonShadowPropertiesDataInterceptor());
		return optionsBuilder;
	}

	/// <summary>
	/// Adds the domain events dispatcher interceptor to the DbContextOptionsBuilder.
	/// </summary>
	/// <param name="optionsBuilder">The DbContextOptionsBuilder.</param>
	/// <returns>The DbContextOptionsBuilder.</returns>
	public static DbContextOptionsBuilder UseDomainEventsDispatcherInterceptor(this DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.AddInterceptors(new DomainEventsDispatcherInterceptor());
		return optionsBuilder;
	}
}

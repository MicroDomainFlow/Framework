using Microsoft.Extensions.DependencyInjection;

namespace MDF.Framework.Extensions.ExtensionMethods;

/// <summary>
/// Contains extension methods for configuring MediatR with a namespace prefix.
/// </summary>
public static class MediatRExtensions
{
	/// <summary>
	/// Adds MediatR services to the specified <see cref="IServiceCollection"/> with the specified namespace prefix.
	/// </summary>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the MediatR services to.</param>
	/// <param name="namespacePrefix">The namespace prefix used to filter assemblies.</param>
	/// <returns>The modified <see cref="IServiceCollection"/>.</returns>
	public static IServiceCollection AddMediatRWithNamespace(this IServiceCollection services, string namespacePrefix)
	{
		var assemblies = AppDomain.CurrentDomain.GetAssemblies()
			.Where(a => a.GetTypes().Any(t => t.Namespace != null && t.Namespace.StartsWith(namespacePrefix)))
			.ToArray();

		services.AddMediatR(c =>
		{
			c.RegisterServicesFromAssemblies(assemblies);
		});

		return services;
	}
}

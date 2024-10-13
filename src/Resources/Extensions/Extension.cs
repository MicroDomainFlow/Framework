using Microsoft.Extensions.DependencyInjection;

namespace Resources.Extensions;
public static class Extension
{
	public static IServiceCollection AddCommonLocalization(this IServiceCollection services,
		string? projectResourcesPath = default)
	{
		if (projectResourcesPath != null)
		{
			services.AddLocalization(options =>
			{
				options.ResourcesPath = "Resources";
				options.ResourcesPath = projectResourcesPath;
			});
		}
		else
		{
			services.AddLocalization(options =>
			{
				options.ResourcesPath = "Resources";
			});
		}
		return services;
	}
}

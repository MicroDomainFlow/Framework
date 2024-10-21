using MDF.SeedWork;

using Microsoft.EntityFrameworkCore;

namespace MDF.Infrastructure.Commands.ShadowProperties;
public static class CommonShadowProperties
{
	/// <summary>
	/// Adds common shadow properties to the model.
	/// </summary>
	/// <param name="modelBuilder">The model builder.</param>
	public static void AddCommonShadowProperties(this ModelBuilder modelBuilder)
	{
		var entityTypes = modelBuilder.Model.GetEntityTypes()
			.Where(e => typeof(IAggregateRoot).IsAssignableFrom(e.ClrType));

		foreach (var entityType in entityTypes)
		{
			if (typeof(IAggregateRoot).IsAssignableFrom(entityType.ClrType))
			{
				modelBuilder.Entity(entityType.ClrType)
					.Property<DateTime>("CreatedDate");

				modelBuilder.Entity(entityType.ClrType)
					.Property<DateTime?>("UpdatedDate");
			}
			else
			{
				modelBuilder.Entity(entityType.ClrType).Ignore("CreatedDate");
				modelBuilder.Entity(entityType.ClrType).Ignore("UpdatedDate");
			}
		}
	}
}

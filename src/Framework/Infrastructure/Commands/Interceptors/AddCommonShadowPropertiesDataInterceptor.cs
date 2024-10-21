using MDF.Framework.SeedWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MDF.Framework.Infrastructure.Commands.Interceptors;

public class AddCommonShadowPropertiesDataInterceptor : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		AddCommonShadowProperties(eventData);
		return base.SavingChanges(eventData, result);
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		AddCommonShadowProperties(eventData);
		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private static void AddCommonShadowProperties(DbContextEventData eventData)
	{
		var changeTracker = eventData.Context.ChangeTracker;

		var addedEntries = changeTracker.Entries()
			.Where(e => e.State == EntityState.Added && e.Entity is IAggregateRoot
			)
			.ToList();
		foreach (var entry in addedEntries)
		{
			entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
		}

		var modifiedEntries = changeTracker.Entries()
			.Where(e => e.State == EntityState.Modified && e.Entity is IAggregateRoot)
			.ToList();
		foreach (var entry in modifiedEntries)
		{
			entry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
		}
	}
}

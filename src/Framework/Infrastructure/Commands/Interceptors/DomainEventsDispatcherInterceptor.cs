using Framework.SeedWork;

using MassTransit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Infrastructure.Commands.Interceptors;
public class DomainEventsDispatcherInterceptor : SaveChangesInterceptor
{
	public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
		CancellationToken cancellationToken = new CancellationToken())
	{
		//این کد چندینبار تکرار میشود البته در هر بار تکرار اتقاقی رخ میدهد مانند ثبت در outbox و استفاده از آن
		var affectedRows = eventData.Context.ChangeTracker
			.Entries()
			.Count(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
		var publishEndpoint = eventData?.Context?.GetService<IPublishEndpoint>();

		if (affectedRows > 0)
		{
			var aggregateRoots =
					eventData.Context?.ChangeTracker.Entries()
						.Where(current => current.Entity is IAggregateRoot)
						.Select(current => current.Entity as IAggregateRoot)
						.ToList()
				;

			if (aggregateRoots != null)
			{
				foreach (var aggregateRoot in aggregateRoots)
				{
					// Dispatch Events!
					if (aggregateRoot != null)
					{
						foreach (var domainEvent in aggregateRoot.DomainEvents.ToList())
						{
							//	await _mediator.Publish(domainEvent, cancellationToken);
							await publishEndpoint?.Publish((object)domainEvent, cancellationToken);
						}

						// Clear Events!
						aggregateRoot.ClearDomainEvents();
					}
				}
			}
		}
		return await base.SavingChangesAsync(eventData, result, cancellationToken); ;
	}

	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		var affectedRows = eventData.Context.ChangeTracker.Entries()
			.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
			.Count();

		if (affectedRows > 0)
		{
			var aggregateRoots =
					eventData.Context?.ChangeTracker.Entries()
						.Where(current => current.Entity is IAggregateRoot)
						.Select(current => current.Entity as IAggregateRoot)
						.ToList()
				;

			if (aggregateRoots != null)
			{
				var publishEndpoint = eventData?.Context?.GetService<IPublishEndpoint>();
				foreach (var aggregateRoot in aggregateRoots)
				{
					// Dispatch Events!
					if (aggregateRoot != null)
					{
						foreach (var domainEvent in aggregateRoot.DomainEvents.ToList())
						{
							//	await _mediator.Publish(domainEvent, cancellationToken);
							publishEndpoint?.Publish((object)domainEvent);
						}

						// Clear Events!
						aggregateRoot.ClearDomainEvents();
					}
				}
			}
		}
		return base.SavingChanges(eventData, result);
	}
}

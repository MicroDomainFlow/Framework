using FluentResults;

namespace MDF.Framework.SeedWork;

/// <summary>
/// پیاده سازی الگوی AggregateRoot
/// توضیحات کامل در مورد این الگو را در آدرس زیر می‌توانید مشاهده نمایید
/// https://martinfowler.com/bliki/DDD_Aggregate.html
/// 
/// </summary>
public abstract class AggregateRoot<TAggregate> : Entity, IAggregateRoot where TAggregate : IAggregateRoot
{
	public new readonly Result Result = new();
	protected AggregateRoot() : base()
	{
		_domainEvents =
			new List<IDomainEvent>();
	}

	[System.Text.Json.Serialization.JsonIgnore]
	private readonly List<IDomainEvent> _domainEvents;

	[System.Text.Json.Serialization.JsonIgnore]
	public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

	protected void RaiseDomainEvent(IDomainEvent? domainEvent)
	{
		if (domainEvent is null)
		{
			return;
		}

		_domainEvents?.Add(domainEvent);
	}

	protected void RemoveDomainEvent(IDomainEvent? domainEvent)
	{
		if (domainEvent is null)
		{
			return;
		}
		_domainEvents?.Remove(domainEvent);
	}

	public void ClearDomainEvents()
	{
		_domainEvents?.Clear();
	}
}
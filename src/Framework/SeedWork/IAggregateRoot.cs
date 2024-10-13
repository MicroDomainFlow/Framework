﻿namespace Framework.SeedWork
{
	public interface IAggregateRoot : IEntity
	{
		void ClearDomainEvents();

		IReadOnlyList<IDomainEvent> DomainEvents { get; }
	}
}

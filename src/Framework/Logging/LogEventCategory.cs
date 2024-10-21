namespace MDF.Logging;
public enum LogEventCategory
{
	Command = 5000,
	CommandHandler = 5001,
	Query = 6000,
	QueryHandler = 6001,
	DomainEvent = 7000,
	DomainEventHandler = 7001,
}

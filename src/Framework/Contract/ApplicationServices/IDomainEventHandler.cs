using Framework.SeedWork;

using MassTransit;

namespace Framework.Contract.ApplicationServices;
/// <summary>
/// این اینترفیس برای پیاده سازی هندلرهایی که برای رویدادهای دامنه استفاده می شود تعریف شده است.
/// </summary>
//public interface IDomainEventHandler<in TDomainEvent> : MediatR.INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
//{
//}

//استفاده از masstransit
public interface IDomainEventHandler<in TDomainEvent> : IConsumer<TDomainEvent> where TDomainEvent : class, IDomainEvent
{
}

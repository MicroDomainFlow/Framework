using FluentResults;

namespace MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS.BaseClasses
{
	/// <summary>
	/// این یک رابط است که برای پردازش درخواست های مختلف از نوع MediatR.IRequest<InfoinaResult> استفاده می شود.
	/// </summary>
	/// <typeparam name="TCommand">نوع درخواست</typeparam>
	public interface IRequestHandler<in TCommand> :
		MediatR.IRequestHandler<TCommand, Result>
		where TCommand : MediatR.IRequest<Result>
	{
	}

	/// <summary>
	/// این یک رابط است که برای دریافت دستورات و ارسال نتیجه به کاربر استفاده می شود.
	/// </summary>
	/// <typeparam name="TCommand">نوع دستور</typeparam>
	/// <typeparam name="TCommandResult">نوع نتیجه</typeparam>
	public interface IRequestHandler<in TCommand, TCommandResult> :
		MediatR.IRequestHandler<TCommand, Result<TCommandResult>>
		where TCommand : MediatR.IRequest<Result<TCommandResult>>
	{
	}

	/// <summary>
	/// این اینترفیس برای دریافت دستورات و ارسال نتیجه آنها به کلاینت استفاده می شود.
	/// </summary>
	/// <typeparam name="TCommand">دستور برای ارسال به سرور</typeparam>
	/// <typeparam name="TCommandResult">نتیجه دستور ارسالی</typeparam>
	//public interface IRequestHandler<in TCommand, TCommandResult> :
	//MediatR.IRequestHandler<TCommand, InfoinaResult<TCommandResult>>
	//where TCommand : MediatR.IRequest<InfoinaResult<TCommandResult>>
	//where TCommandResult : InfoinaResult<TCommandResult>
	//{
	//}
}

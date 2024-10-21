using FluentResults;

namespace MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

/// <summary>
/// تعریف ساختار مورد نیاز جهت پردازش یک دستور
/// شی InfoinaResult حاوی پیام های خطا و یا موفقیت است
/// </summary>
/// <typeparam name="TCommand">نوع دستور را مشخص می کند</typeparam>
public interface ICommandHandler<in TCommand> :
MediatR.IRequestHandler<TCommand, Result>
where TCommand : ICommand
{
	//یک micro type/tiny type از اینترفیس  MediatR.IRequest میباشد برای راحتی و خوانایی بیشتر
}
/// <summary>
/// تعریف ساختار مورد نیاز جهت پردازش یک دستور
/// شی InfoinaResult حاوی پیام های خطا و یا موفقیت است به همراه مقدار بازگشتی
/// اگر دارای خطا باشد خصوصیت IsFailed برابر با true  می باشد و مقدار این شی default آن نوع مشود
/// </summary>
/// <typeparam name="TCommand">نوع دستور را مشخص می کند</typeparam>
/// <typeparam name="TCommandResult">نوع داده بازگشتی را مشخص میکند</typeparam>
public interface ICommandHandler<in TCommand, TCommandResult> :
	MediatR.IRequestHandler<TCommand, Result<TCommandResult>>
	where TCommand : ICommand<TCommandResult> //ایا TCommandResult  باید از نوع Result<T> باشد؟
{
	//یک micro type/tiny type از اینترفیس  MediatR.IRequest میباشد برای راحتی و خوانایی بیشتر
}


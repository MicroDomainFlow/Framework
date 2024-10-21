using FluentResults;

namespace MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS.BaseClasses;
/// <summary>
/// این اینترفیس برای ایجاد درخواست برای استفاده از MediatR و برای بازگشت نتیجه InfoinaResult استفاده می شود.
/// </summary>
internal interface IRequest :
	MediatR.IRequest<Result>
{
}

/// <summary>
/// این یک رابط برای ارسال درخواست هایی است که نتیجه آنها یک نتیجه InfoinaResult<TReturnValue> است.
/// </summary>
/// <typeparam name="TReturnValue">نوع نتیجه ای که باید برگردانده شود</typeparam>
internal interface IRequest<TReturnValue> :
	MediatR.IRequest<Result<TReturnValue>>
{
}

/// <summary>
/// این اینترفیس برای ایجاد درخواست هایی که نتیجه آنها یک نوع از کلاس InfoinaResult باشد تعریف شده است.
/// </summary>
/// <typeparam name="TReturnValue">نوع نتیجه درخواست</typeparam>
/// <returns>یک نوع از کلاس InfoinaResult</returns>
//internal interface IRequest<TReturnValue> :
//	MediatR.IRequest<InfoinaResult<TReturnValue>>
//	where TReturnValue : InfoinaResult<TReturnValue>
//{
//}
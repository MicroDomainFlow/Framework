using FluentResults;

namespace Framework.Contract.ApplicationServices.MediatorExtensions.CQRS;
/// <summary>
/// تعریف ساختار مورد نیاز جهت پردازش یک کورئری
/// شی InfoinaResult حاوی پیام های خطا و یا موفقیت است به همراه مقدار بازگشتی
/// اگر دارای خطا باشد خصوصیت IsFailed برابر با true  می باشد و مقدار این شی default آن نوع مشود
/// </summary>
/// <typeparam name="TQuery">نوع کوئری و پارامتر‌های ورودی را تعیین می‌کند</typeparam>
/// <typeparam name="TQueryResult">نوع داده‌های بازگشتی را تعیین می‌کند</typeparam>
public interface IQueryHandler<in TQuery, TQueryResult> :
	MediatR.IRequestHandler<TQuery, Result<TQueryResult>>
	where TQuery : IQuery<TQueryResult>
{
	//یک micro type/tiny type از اینترفیس  MediatR.IRequest میباشد برای راحتی و خوانایی بیسشتر
}
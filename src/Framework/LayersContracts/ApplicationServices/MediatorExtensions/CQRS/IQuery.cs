using FluentResults;

using System.Reflection;
using System.Text;

namespace MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;
/// <summary>
/// اینترفیسی جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند!
/// </summary>
/// <typeparam name="TQueryResult">نوع بازگشتی را تعیین می‌کند</typeparam>
public interface IQuery<TQueryResult> : MediatR.IRequest<Result<TQueryResult>>
{
	//یک micro type/tiny type از اینترفیس  MediatR.IRequest میباشد برای راحتی و خوانایی بیسشتر
}


/// <summary>
/// این کلاس یک نوع از نوع IQuery است که برای ساختن یک رشته از نام و مقدار ورودی های یک نوع استفاده می شود.
/// </summary>
/// <returns>
/// رشته ای از نام و مقدار ورودی های یک نوع.
/// </returns>
public abstract class BaseQuery<TQueryResult> : IQuery<TQueryResult>
{
	public override string ToString()
	{
		// این کد برای ساختن یک رشته از نام و مقدار ورودی های یک نوع استفاده می شود
		var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
		// یک شی از نوع StringBuilder برای ساختن رشته ایجاد می شود
		var stringBuilder = new StringBuilder();
		// یک حلقه برای بررسی هر ورودی استفاده می شود
		foreach (var property in properties)
		{
			// نام و مقدار ورودی بررسی می شود
			var name = property.Name;
			var value = property.GetValue(this);
			// نام و مقدار ورودی به رشته اضافه می شود
			stringBuilder.Append($"{name}: {value}, ");
		}
		// نام نوع خروجی به رشته اضافه می شود
		stringBuilder.Append($"TQueryResult: {typeof(TQueryResult).Name}");
		// رشته برگشت داده می شود
		return stringBuilder.ToString();
	}
}
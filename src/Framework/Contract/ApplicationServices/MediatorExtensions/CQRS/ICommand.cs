using FluentResults;

using System.Reflection;
using System.Text;

namespace Framework.Contract.ApplicationServices.MediatorExtensions.CQRS
{
	/// <summary>
	/// جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس استفاده می‌شود
	/// شی InfoinaResult حاوی پیام های خطا و یا موفقیت است
	/// </summary>
	public interface ICommand : MediatR.IRequest<Result>
	{
		//یک micro type/tiny type از اینترفیس  MediatR.IRequest میباشد برای راحتی و خوانایی بیسشتر

	}
	/// <summary>
	///در صورتی که از نوع class استفاده میکنید از این استفاده کنید
	/// این کلاس پایه یک دستور را پیادهسازی می کند و تمامی ویژگی های آن را به صورت یک رشته برمی گرداند.
	/// </summary>
	/// <returns>
	/// رشته ای که شامل ویژگی های کلاس پایه است.
	/// </returns>
	public abstract class BaseCommand : ICommand
	{
		public override string ToString()
		{
			// این کد برای بدست آوردن اطلاعات مربوط به یک نوع داده است
			var properties = GetType().GetProperties();
			// ایجاد یک شیء از نوع StringBuilder
			var stringBuilder = new StringBuilder();
			// برای هر خاصیت در نوع داده
			foreach (var property in properties)
			{
				// بدست آوردن نام خاصیت
				var name = property.Name;
				// بدست آوردن مقدار خاصیت
				var value = property.GetValue(this);
				// اضافه کردن نام و مقدار به شیء StringBuilder
				stringBuilder.Append($"{name}: {value}, ");
			}
			// بازگشت اطلاعات به صورت یک رشته و حذف کاما از آخر رشته
			return stringBuilder.ToString().TrimEnd(',', ' ');
		}
	}
	/// <summary>
	/// جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس استفاده می‌شود
	/// اگر به ازای دستور ارسال شده مقدار خروجی باید بازگشت داده شود از این اینترفیس استفاده می‌شود
	/// شی InfoinaResult حاوی پیام های خطا و یا موفقیت است به همراه مقدار بازگشتی
	/// اگر دارای خطا باشد خصوصیت IsFailed برابر با true  می باشد و مقدار این شی default آن نوع مشود
	/// </summary>
	/// <typeparam name="TCommandResult">نوع داده‌ای که در ازای دستور باید بازگشت داده شود</typeparam>
	public interface ICommand<TCommandResult> : MediatR.IRequest<Result<TCommandResult>>
	{
		//یک micro type/tiny type از اینترفیس  MediatR.IRequest میباشد برای راحتی و خوانایی بیسشتر
	}

	/// <summary>
	/// در صورتی که از نوع class استفاده میکنید از این استفاده کنید
	/// این کلاس پایه یک دستور را پیادهسازی می کند و نام و مقادیر خاصی از خصوصیات را برای آن به عنوان یک رشته برمی گرداند.
	/// </summary>
	/// <returns>
	/// رشته ای از نام و مقادیر خاصی از خصوصیات کلاس.
	/// </returns>
	public abstract class BaseCommand<TCommandResult> : ICommand<TCommandResult>
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
			stringBuilder.Append($"TCommandResult: {typeof(TCommandResult).Name}");
			// رشته برگشت داده می شود
			return stringBuilder.ToString();
		}
	}
}

using FluentResults;

using FluentValidation.Results;

using MDF.Framework.SeedWork;

namespace MDF.Framework.Extensions.Results;
/// <summary>
/// این کلاس برای اعتبارسنجی خود ValueObject ها میشباشد
/// برپایه کتابخانه های FluentResult و FluentValidation نوشته شده است
/// و نیاز به شی AbstractValidator<typeparam name="Generic">T</typeparam>> دارد
/// </summary>
public static class ValueObjectValidation
{
	/// <summary>
	/// این متد به نتیجه اضافه می‌کند والیدیشن ارورهای مربوط به یک ValidationResult را
	/// </summary>
	/// <typeparam name="T">  که باید از نوع ValueObject باشد.نوع مقداری که در نتیجه استفاده می‌شود</typeparam>
	/// <param name="result">شی FluentResult </param>
	/// <param name="validationResult">شی ValidationResultاست که حاوی ارورها</param>
	/// <returns>
	/// نتیجه با اضافه شدن ارورهای والیدیشن
	/// </returns>
	public static Result<T> AddValidationErrors<T>(this Result<T> result, ValidationResult validationResult)
	where T : ValueObject
	{
		if (!validationResult.IsValid)
		{
			foreach (var failure in validationResult.Errors)
			{
				result.WithError(failure.ErrorMessage);
			}
		}

		return result;
	}
}


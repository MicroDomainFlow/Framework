using MediatR;

namespace MDF.Contract.ApplicationServices.MediatorExtensions;

/// <summary>
/// ولیدیشن های مربوط به کتابخانه MediatR
/// </summary>
/// <typeparam name="TRequest">از جنس IRequest<TResponse> می باشد.</typeparam>
/// <typeparam name="TResponse">مقدار برگشتی.</typeparam>
public class ValidationBehavior<TRequest, TResponse> :
	IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	public ValidationBehavior
		(IEnumerable<FluentValidation.IValidator<TRequest>> validators)
	{
		Validators = validators;
	}

	protected IEnumerable<FluentValidation.IValidator<TRequest>> Validators { get; }

	/// <summary>
	/// این متد برای اعتبارسنجی درخواست های ورودی استفاده می شود و در صورت عدم تطابق با قوانین اعتبارسنجی، یک استثنای اعتبارسنجی را صادر می کند.
	/// <param name="request"></param>
	/// <param name="next"></param>
	/// <param name="cancellationToken"></param>
	/// </summary>
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		// اگر والیدیتورها وجود داشته باشند
		if (Validators.Any())
		{
			// یک متغیر برای ساختن شرایط اعتبارسنجی ایجاد می کنیم
			var context =
				new FluentValidation.ValidationContext<TRequest>(request);

			// یک آرایه از نتایج اعتبارسنجی را با استفاده از والیدیتورها ایجاد می کنیم
			var validationResults =
				await Task.WhenAll
				(Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

			// اشکالات را از نتایج اعتبارسنجی انتخاب می کنیم
			var failures =
				validationResults
				.SelectMany(current => current.Errors)
				.Where(current => current != null)
				.ToList();

			// اگر اشکالات وجود داشته باشند
			if (failures.Count != 0)
			{
				// یک استثنای اعتبارسنجی را با اشکالات ایجاد می کنیم
				throw new FluentValidation.ValidationException(errors: failures);
			}
		}

		// بعد از اعتبارسنجی، به عملیات بعدی می رویم
		return await next();
	}
}

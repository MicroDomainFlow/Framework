using System.Collections;
using MDF.Resources.Common.FormattedMessages;

namespace MDF.Framework.Extensions.Guards.GuardClauses;

public static class MinimumLengthGuardClause
{
	public static Guard<T?> MinimumLength<T>(this Guard<T?> guard, int minimumLength)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value?.ToString()?.Length < minimumLength)
		{
			guard._result.WithError(ValidationMessages.MinLength(guard._propertyName, minimumLength));
			return guard;
		}



		var value = guard._value as ICollection;
		if (value?.Count < minimumLength)
			guard._result.WithError(ValidationMessages.MinLength(guard._propertyName, minimumLength));

		return guard;
	}
}

using Resources.Common.FormattedMessages;

using System.Collections;

namespace MDF.Extensions.Guards.GuardClauses;

public static class MaximumLengthGuardClause
{
	public static Guard<T?> MaximumLength<T>(this Guard<T?> guard, int maximumLength)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));
		if (guard._value is string value)
		{
			if (value.Length > maximumLength)
				guard._result.WithError(ValidationMessages.MaxLength(guard._propertyName, maximumLength));
		}
		else if (guard._value is ICollection collection)
		{
			if (collection.Count > maximumLength)
				guard._result.WithError(ValidationMessages.MaxLength(guard._propertyName, maximumLength));
		}

		return guard;
	}
}

using Resources.Common.FormattedMessages;

using System.Collections;

namespace Framework.Extensions.Guards.GuardClauses;

public static class LengthGuardClause
{
	public static Guard<T?> Length<T>(this Guard<T?> guard, int length)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value is string value)
		{
			if (value.Length != length)
				guard._result.WithError(ValidationMessages.FixLengthNumeric(guard._propertyName, length));
		}
		else if (guard._value is ICollection collection)
		{
			if (collection.Count != length)
				guard._result.WithError(ValidationMessages.FixLengthNumeric(guard._propertyName, length));
		}

		return guard;
	}
}

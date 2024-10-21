using MDF.Resources.Common.FormattedMessages;

namespace MDF.Framework.Extensions.Guards.GuardClauses;

public static class NotEqualGuardClause
{
	public static Guard<T?> NotEqual<T>(this Guard<T> guard, T targetValue)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (Equals(guard._value, targetValue))
			guard._result.WithError(ValidationMessages.Equality(guard._propertyName, targetValue.ToString()));

		return guard;
	}
}
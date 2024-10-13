using Resources.Common.FormattedMessages;

namespace Framework.Extensions.Guards.GuardClauses;

public static class EqualGuardClause
{
	public static Guard<T?> Equal<T>(this Guard<T?> guard, T targetValue)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (!Equals(guard._value, targetValue))
			guard._result.WithError(ValidationMessages.EmptyOrOtherValue(guard._propertyName, targetValue));
		return guard;
	}

	public static Guard<T?> Equal<T>(this Guard<T?> guard, T targetValue, IEqualityComparer<T> equalityComparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (!equalityComparer.Equals((dynamic)guard._value, targetValue))
			guard._result.WithError(ValidationMessages.EmptyOrOtherValue(guard._propertyName, targetValue));

		return guard;
	}
}
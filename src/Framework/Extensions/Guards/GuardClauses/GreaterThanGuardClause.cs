using Resources.Common.FormattedMessages;

namespace Framework.Extensions.Guards.GuardClauses;

public static class GreaterThanGuardClause
{
	public static Guard<T?> GreaterThan<T>(this Guard<T?> guard, T minimumValue, IComparer<T> comparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		int maximumValueComparerResult = comparer.Compare((dynamic)guard._value, minimumValue);

		if (maximumValueComparerResult != 1)
			guard._result.WithError(ValidationMessages.GreaterThan_FieldValue(guard._propertyName, minimumValue));
		return guard;
	}

	public static Guard<T?> GreaterThan<T>(this Guard<T?> guard, T minimumValue)
		where T : IComparable<T>, IComparable
	{
		guard.GreaterThan(minimumValue, Comparer<T>.Default);
		return guard;
	}
}
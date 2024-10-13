using Resources.Common.FormattedMessages;

namespace Framework.Extensions.Guards.GuardClauses;

public static class LessThanGuardClause
{
	public static Guard<T?> LessThan<T>(this Guard<T?> guard, T maximumValue, IComparer<T> comparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		int comparerResult = comparer.Compare((dynamic)guard._value, maximumValue);

		if (comparerResult > -1)
			guard._result.WithError(ValidationMessages.LessThan_FieldValue(guard._propertyName, maximumValue));

		return guard;
	}

	public static Guard<T?> LessThan<T>(this Guard<T?> guard, T maximumValue)
		where T : IComparable<T>, IComparable
	{
		guard.LessThan(maximumValue, Comparer<T>.Default);
		return guard;
	}
}
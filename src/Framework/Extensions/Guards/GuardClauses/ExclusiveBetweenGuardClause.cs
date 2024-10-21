using Resources.Common.FormattedMessages;

namespace MDF.Extensions.Guards.GuardClauses;

public static class ExclusiveBetweenGuardClause
{
	public static Guard<T?> ExclusiveBetween<T>(this Guard<T?> guard, T minimumValue, T maximumValue, IComparer<T> comparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		int minimumValueComparerResult = comparer.Compare((dynamic)guard._value, minimumValue);
		int maximumValueComparerResult = comparer.Compare((dynamic)guard._value, maximumValue);

		if (minimumValueComparerResult != 1)
			guard._result.WithError(ValidationMessages.MinLength(guard._propertyName, minimumValue));

		if (maximumValueComparerResult != -1)
			guard._result.WithError(ValidationMessages.MaxLength(guard._propertyName, maximumValue));

		return guard;
	}

	public static Guard<T?> ExclusiveBetween<T>(this Guard<T?> guard, T minimumValue, T maximumValue)
		where T : IComparable<T>, IComparable
	{
		guard.ExclusiveBetween(minimumValue, maximumValue, Comparer<T>.Default);
		return guard;
	}

	public static Guard<T?> LengthExclusiveBetween<T>(this Guard<T?> guard, int minimumLength, int maximumLength)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		int length = ((string)(object)guard._value).Length;

		if (length <= minimumLength || length >= maximumLength)
			guard._result.WithError(ValidationMessages.Range(guard._propertyName, minimumLength, maximumLength));

		return guard;
	}
}

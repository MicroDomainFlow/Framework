using MDF.Resources.Common.FormattedMessages;

namespace MDF.Framework.Extensions.Guards.GuardClauses;

public static class LessThanOrEqualGuardClause
{
	public static Guard<T?> LessThanOrEqual<T>(this Guard<T?> guard, T minimumValue, IComparer<T> comparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		int comparerResult = comparer.Compare((dynamic)guard._value, minimumValue);

		if (comparerResult > 0)
			guard._result.WithError(ValidationMessages.LessThan_FieldValue(guard._propertyName, minimumValue));
		return guard;
	}

	public static Guard<T?> LessThanOrEqual<T>(this Guard<T?> guard, T minimumValue)
		where T : IComparable<T>, IComparable
	{
		guard.LessThanOrEqual(minimumValue, Comparer<T>.Default);
		return guard;
	}
}
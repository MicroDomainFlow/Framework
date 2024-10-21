using System.Collections;
using Resources.Common.FormattedMessages;

namespace MDF.Extensions.Guards.GuardClauses;


public static class EmptyGuardClause
{
	public static Guard<T?> Empty<T>(this Guard<T?> guard)
	{
		if (string.IsNullOrEmpty(value: guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value == null)
			return guard;

		if (guard._value is ICollection collectionValue && collectionValue.Count == 0)
			return guard;

		if (guard._value is IEnumerable enumerableValue && !enumerableValue.GetEnumerator().MoveNext())
			return guard;

		if (guard._value is string strValue && string.IsNullOrWhiteSpace(strValue))
			return guard;

		if (!Equals(guard._value, default(T)))
			guard._result.WithError(ValidationMessages.EmptyOrDefault(guard._propertyName));

		return guard;
	}


	public static Guard<T?> Empty<T>(this Guard<T?> guard, IEqualityComparer<T> equalityComparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (!equalityComparer.Equals((dynamic)guard._value, default(T))) ;
		guard._result.WithError(ValidationMessages.EmptyOrDefault(guard._propertyName));

		return guard;
	}

}
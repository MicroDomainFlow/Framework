using MDF.Resources.Common.FormattedMessages;

using System.Collections;

namespace MDF.Framework.Extensions.Guards.GuardClauses;

public static class NotEmptyGuardClause
{
	public static Guard<T?> NotEmpty<T>(this Guard<T?> guard)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value == null)
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value is ICollection collectionValue && collectionValue.Count == 0)
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value is IEnumerable enumerableValue && !enumerableValue.GetEnumerator().MoveNext())
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value is string strValue && string.IsNullOrWhiteSpace(strValue))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (EqualityComparer<T>.Default.Equals((dynamic)guard._value, default(T)))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (EqualityComparer<T>.Default.Equals((dynamic)guard._value, default(T)) || guard._value is Guid guidValue && guidValue == Guid.Empty)
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		return guard;
	}

	public static Guard<T?> NotEmpty<T>(this Guard<T?> guard, IEqualityComparer<T?> equalityComparer)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (equalityComparer.Equals((dynamic)guard._value, default(T)))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (EqualityComparer<T>.Default.Equals((dynamic)guard._value, default(T)) || guard._value is Guid guidValue && guidValue == Guid.Empty)
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		return guard;
	}
}
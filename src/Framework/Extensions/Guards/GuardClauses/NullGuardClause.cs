using Resources.Common.FormattedMessages;

namespace Framework.Extensions.Guards.GuardClauses;

public static class NullGuardClause
{
	public static Guard<T?> Null<T>(this Guard<T?> guard)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (guard._value != null)
			guard._result.WithError(ValidationMessages.Null(guard._propertyName));

		return guard;
	}
}

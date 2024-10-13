using Resources.Common.FormattedMessages;

using System.Text.RegularExpressions;

namespace Framework.Extensions.Guards.GuardClauses;

public static class MatchGuardClause
{
	public static Guard<T?> Match<T>(this Guard<T?> guard, string pattern)
	{
		if (string.IsNullOrEmpty(guard._propertyName))
			guard._result.WithError(ValidationMessages.Required(guard._propertyName));

		if (!Regex.IsMatch((dynamic)guard._value.ToString(), pattern))
			guard._result.WithError(ValidationMessages.RegularExpression(guard._propertyName));

		return guard;
	}
}
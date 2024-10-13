using Resources.Common.Messages;

namespace Resources.Common.FormattedMessages;
public static class SuccessMessages
{
	public static string CellPhoneNumberVerified => Successes.CellPhoneNumberVerified;
	public static string EmailAddressVerified => Successes.EmailAddressVerified;
	public static string SuccessCreate(string input) => string.Format(Successes.SuccessCreate, input);
	public static string SuccessDelete(string input) => string.Format(Successes.SuccessDelete, input);
	public static string SuccessUpdate(string input) => string.Format(Successes.SuccessUpdate, input);
	public static string SuccessUserPasswordChanged => Successes.SuccessUserPasswordChanged;
}

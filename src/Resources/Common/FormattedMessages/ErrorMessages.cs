using MDF.Resources.Common.Messages;

namespace MDF.Resources.Common.FormattedMessages;
public static class ErrorMessages
{
	public static string CanNotDelete(string fieldName) => string.Format(Errors.CanNotDelete, fieldName);
	public static string NotFound(string fieldName) => string.Format(Errors.NotFound, fieldName);
	public static string CellPhoneNumberAlreadyVerified => string.Format(Errors.CellPhoneNumberAlreadyVerified);
	public static string EmailAddressAlreadyVerified => string.Format(Errors.EmailAddressAlreadyVerified);
	public static string InvalidVerificationKey => string.Format(Errors.InvalidVerificationKey);
	public static string UnexpectedError => string.Format(Errors.UnexpectedError);
}

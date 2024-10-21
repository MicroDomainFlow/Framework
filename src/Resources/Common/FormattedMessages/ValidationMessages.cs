using MDF.Resources.Common.Messages;

namespace MDF.Resources.Common.FormattedMessages;
/// <summary>
/// پیام های اعتبار سنجی
/// درصورتی که از کتابخانه FluentValidation استفاده میکنید نیازی به استفاده از این پیام ها ندارید
/// </summary>
public static class ValidationMessages
{
	public static string FixLengthNumeric(string fieldName, string length) => string.Format(Validations.FixLengthNumeric, fieldName, length);
	public static string FixLengthNumeric(string fieldName, dynamic length) => string.Format(Validations.FixLengthNumeric, fieldName, length.ToString());
	public static string GreaterThan_FieldValue(string fieldNameOne, string length) => string.Format(Validations.GreaterThan_FieldValue, fieldNameOne, length);
	public static string GreaterThan_FieldValue(string fieldNameOne, dynamic length) => string.Format(Validations.GreaterThan_FieldValue, fieldNameOne, length.ToString());
	public static string GreaterThan_TwoFields(string fieldNameOne, dynamic fieldNameTwo) => string.Format(Validations.GreaterThan_TwoFields, fieldNameOne, fieldNameTwo.ToString());
	public static string GreaterThanOrEqualTo_FieldValue(string fieldNameOne, string length) => string.Format(Validations.GreaterThanOrEqualTo_FieldValue, fieldNameOne, length);
	public static string GreaterThanOrEqualTo_FieldValue(string fieldNameOne, dynamic length) => string.Format(Validations.GreaterThanOrEqualTo_FieldValue, fieldNameOne, length.ToString());
	public static string GreaterThanOrEqualTo_TwoFields(string theFieldShouldBeLarger, string otherFieldName) => string.Format(Validations.GreaterThanOrEqualTo_TwoFields, theFieldShouldBeLarger, otherFieldName);
	//
	public static string LessThan_FieldValue(string fieldNameOne, string length) => string.Format(Validations.LessThan_FieldValue, fieldNameOne, length);
	public static string LessThan_FieldValue(string fieldNameOne, dynamic length) => string.Format(Validations.LessThan_FieldValue, fieldNameOne, length.ToString());
	public static string LessThan_TwoFields(string fieldNameOne, dynamic fieldNameTwo) => string.Format(Validations.LessThan_TwoFields, fieldNameOne, fieldNameTwo.ToString());
	public static string LessThanOrEqualTo_FieldValue(string fieldNameOne, string length) => string.Format(Validations.LessThanOrEqualTo_FieldValue, fieldNameOne, length);
	public static string LessThanOrEqualTo_FieldValue(string fieldNameOne, dynamic length) => string.Format(Validations.LessThanOrEqualTo_FieldValue, fieldNameOne, length.ToString());
	public static string LessThanOrEqualTo_TwoFields(string theFieldShouldBeLarger, string otherFieldName) => string.Format(Validations.LessThanOrEqualTo_TwoFields, theFieldShouldBeLarger, otherFieldName);
	public static string InvalidCode(string fieldName, dynamic code) => string.Format(Validations.InvalidCode, fieldName, code.ToString());
	public static string InvalidField(string fieldName) => string.Format(Validations.InvalidField, fieldName);
	public static string MaxLength(string fieldName, dynamic maximumLengthNumber) => string.Format(Validations.MaxLength, fieldName, maximumLengthNumber.ToString());
	public static string MinLength(string fieldName, dynamic minimumLengthNumber) => string.Format(Validations.MinLength, fieldName, minimumLengthNumber.ToString());
	public static string Range(string fieldName, dynamic maximumLengthNumber, dynamic minimumLengthNumber) => string.Format(Validations.Range, fieldName, maximumLengthNumber.ToString(), minimumLengthNumber.ToString());
	public static string RegularExpression(string fieldName) => string.Format(Validations.RegularExpression, fieldName);
	public static string Repetitive(string input) => string.Format(Validations.Repetitive, input);
	public static string Required(string fieldName) => string.Format(Validations.Required, fieldName);
	public static string NotNull(string fieldName) => string.Format(Validations.NotNull, fieldName);
	public static string Null(string fieldName) => string.Format(Validations.Null, fieldName);
	public static string Equality(string valueOne, string valueTwo) => string.Format(Validations.Equality, valueOne, valueTwo);
	public static string EmptyOrDefault(string fieldName) => string.Format(Validations.EmptyOrDefault, fieldName);
	public static string EmptyOrOtherValue(string fieldName, object otherValue) => string.Format(Validations.EmptyOrOtherValue, fieldName, otherValue);
}
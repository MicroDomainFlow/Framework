using Resources.Common.FormattedMessages;
using Resources.Common.Messages;

namespace Framework.Tests.Unit.Resources;
public class ValidationMessagesTests
{

	[Fact]
	public void FixLengthNumeric_WhenCalled_ReturnsFormattedString()
	{
		// Arrange
		string fieldName = "Field1";
		string lengthNumber = "10";
		var message = "مقدار فیلد Field1 باید دقیقا 10 رقم باشد!";

		// Act
		string result = ValidationMessages.FixLengthNumeric(fieldName, lengthNumber);

		// Assert
		Assert.Equal(message, result);
	}

	[Fact]
	public void FixLengthNumeric_WithFieldNameAndLengthNumber_ShouldReturnFormattedString()
	{
		// Arrange
		string fieldName = "Field1";
		dynamic lengthNumber = 10;
		var message = "مقدار فیلد Field1 باید دقیقا 10 رقم باشد!";

		// Act
		string result = ValidationMessages.FixLengthNumeric(fieldName, lengthNumber);

		// Assert
		Assert.Equal(message, result);
	}

	[Fact]
	public void GreaterThan_FieldValue_ReturnsCorrectMessage()
	{
		// Arrange
		string fieldNameOne = "Field1";
		string fieldNameTwoIsLarger = "Field2";
		var message = string.Format(Validations.GreaterThan_FieldValue, fieldNameOne, fieldNameTwoIsLarger);
		// Act
		string result = ValidationMessages.GreaterThan_FieldValue(fieldNameOne, fieldNameTwoIsLarger);

		// Assert
		Assert.Equal(message, result);
	}

	[Fact]
	public void GreaterThan_TwoFields_WhenCalled_ReturnsFormattedMessage()
	{
		// Arrange
		string fieldNameOne = "Field1";
		dynamic fieldNameTwo = "Field2";
		var message = string.Format(Validations.GreaterThan_TwoFields, fieldNameOne, fieldNameTwo);

		// Act
		string result = ValidationMessages.GreaterThan_TwoFields(fieldNameOne, fieldNameTwo);

		// Assert
		Assert.Equal(message, result);
	}


	[Fact]
	public void GreaterThanOrEqualTo_FieldValue_ReturnsCorrectMessage()
	{
		// Arrange
		string fieldNameOne = "Field1";
		string fieldNameTwo = "Field2";
		string expectedMessage = string.Format(Validations.GreaterThanOrEqualTo_FieldValue, fieldNameOne, fieldNameTwo);

		// Act
		string actualMessage = ValidationMessages.GreaterThanOrEqualTo_FieldValue(fieldNameOne, fieldNameTwo);

		// Assert
		Assert.Equal(expectedMessage, actualMessage);
	}

	[Fact]
	public void GreaterThanOrEqualTo_TwoFields_ReturnsCorrectMessage()
	{
		// Arrange
		string theFieldShouldBeLarger = "Field1";
		string otherFieldName = "Field2";
		string expectedMessage = string.Format(Validations.GreaterThanOrEqualTo_TwoFields, theFieldShouldBeLarger, otherFieldName);

		// Act
		string result = ValidationMessages.GreaterThanOrEqualTo_TwoFields(theFieldShouldBeLarger, otherFieldName);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void InvalidCode_ReturnsCorrectMessage()
	{
		// Arrange
		string fieldName = "Field1";
		dynamic code = 123;
		string expectedMessage = string.Format(Validations.InvalidCode, fieldName, code);

		// Act
		string result = ValidationMessages.InvalidCode(fieldName, code);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void MaxLength_ReturnsCorrectMessage()
	{
		// Arrange
		string fieldName = "Username";
		dynamic maximumLengthNumber = 10;
		string expectedMessage = string.Format(Validations.MaxLength, fieldName, maximumLengthNumber);

		// Act
		string result = ValidationMessages.MaxLength(fieldName, maximumLengthNumber);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void MinLength_ReturnsCorrectMessage()
	{
		// Arrange
		string fieldName = "Username";
		dynamic minimumLengthNumber = 5;
		string expectedMessage = string.Format(Validations.MinLength, fieldName, minimumLengthNumber);

		// Act
		string result = ValidationMessages.MinLength(fieldName, minimumLengthNumber);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void NotFound_ReturnsCorrectMessage()
	{
		// Arrange
		string fieldName = "Username";
		string expectedMessage = string.Format(Errors.NotFound, fieldName);

		// Act
		string result = ErrorMessages.NotFound(fieldName);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void Range_WithValidInputs_ShouldReturnFormattedMessage()
	{
		// Arrange
		string fieldName = "Age";
		dynamic maximumLengthNumber = 10;
		dynamic minimumLengthNumber = 1;
		string expectedMessage = string.Format(Validations.Range, fieldName, maximumLengthNumber, minimumLengthNumber);

		// Act
		string result = ValidationMessages.Range(fieldName, maximumLengthNumber, minimumLengthNumber);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void Range_WithNegativeNumbers_ShouldReturnFormattedMessage()
	{
		// Arrange
		string fieldName = "Length";
		dynamic maximumLengthNumber = -5;
		dynamic minimumLengthNumber = -10;
		string expectedMessage = string.Format(Validations.Range, fieldName, maximumLengthNumber, minimumLengthNumber);

		// Act
		string result = ValidationMessages.Range(fieldName, maximumLengthNumber, minimumLengthNumber);

		// Assert
		Assert.Equal(expectedMessage, result);
	}


	[Fact]
	public void RegularExpression_WithValidFieldName_ReturnsCorrectFormat()
	{
		// Arrange
		string fieldName = "Email";
		string expectedMessage = string.Format(Validations.RegularExpression, fieldName);

		// Act
		string result = ValidationMessages.RegularExpression(fieldName);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void RegularExpression_WithEmptyFieldName_ReturnsCorrectFormat()
	{
		// Arrange
		string fieldName = "";
		string expectedMessage = string.Format(Validations.RegularExpression, fieldName);

		// Act
		string result = ValidationMessages.RegularExpression(fieldName);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void RegularExpression_WithNullFieldName_ReturnsCorrectFormat()
	{
		// Arrange
		string fieldName = null;
		string expectedMessage = string.Format(Validations.RegularExpression, fieldName);

		// Act
		string result = ValidationMessages.RegularExpression(fieldName);

		// Assert
		Assert.Equal(expectedMessage, result);
	}


	[Fact]
	public void Repetitive_InputString_ReturnsFormattedMessage()
	{
		// Arrange
		string input = "test";
		string expectedMessage = string.Format(Validations.Repetitive, input);

		// Act
		string result = ValidationMessages.Repetitive(input);

		// Assert
		Assert.Equal(expectedMessage, result);
	}

	[Fact]
	public void Repetitive_NullInput_ReturnsNull()
	{
		// Arrange
		string input = null;
		string expectedMessage = string.Format(Validations.Repetitive, input);

		// Act
		string result = ValidationMessages.Repetitive(input);

		// Assert
		Assert.Equal(expectedMessage, result);
	}



	[Fact]
	public void Required_WithFieldName_ReturnsRequiredMessage()
	{
		// Arrange
		string fieldName = "Username";
		string expectedMessage = string.Format(Validations.Required, fieldName);

		// Act
		string result = ValidationMessages.Required(fieldName);

		// Assert
		Assert.Equal(expectedMessage, result);
	}
}



using FluentResults;

using MDF.Extensions.Guards;
using MDF.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards;
public class GuardTests
{
	[Fact]
	public void ShouldBe_ThrowsGuardException_When_ValueIsNull()
	{
		// Arrange
		string? value = null;
		string propertyName = "Value";

		// Act
		var ex = Record.Exception(() => Guard.CheckIf(value, propertyName)
		.NotNull()
		.ThrowIfFailed());

		// Assert
		Assert.NotNull(ex);
	}

	[Fact]
	public void ShouldBe_DoesNotThrowGuardException_When_ValueIsNotNull()
	{
		// Arrange
		string value = "Test";
		string propertyName = "Value";

		// Act
		var ex = Record.Exception(() => Guard.CheckIf(value, propertyName).ThrowIfFailed());

		// Assert
		Assert.Null(ex);// No exception should be thrown
	}

	[Fact]
	public void ShouldBe_StringValueIsFixed()
	{
		// Arrange
		string value = "  Test  ";
		string propertyName = "Value";

		// Act
		Result<string> result = Guard.CheckIf(value, propertyName)._result;

		// Assert
		Assert.Equal("Test", result.Value);
	}
}

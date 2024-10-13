using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class MaximumLengthGuardClauseTests
{
	[Fact]
	public void Should_ReturnSuccessfulResult_When_ValueIsNull()
	{
		// Arrange
		var guard = Guard.CheckIf<string>(null, "PropertyName");

		// Act
		var result = guard.MaximumLength(10);

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnSuccessfulResult_When_ValueIsEmptyString()
	{
		// Arrange
		var guard = Guard.CheckIf(string.Empty, "PropertyName");

		// Act
		var result = guard.MaximumLength(10);

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnSuccessfulResult_When_ValueLengthIsLessThanMaximumLength()
	{
		// Arrange
		var guard = Guard.CheckIf("Value", "PropertyName");

		// Act
		var result = guard.MaximumLength(10);

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnFailedResult_When_ValueLengthIsGreaterThanMaximumLength()
	{
		// Arrange
		var guard = Guard.CheckIf("Value", "PropertyName");

		// Act
		var result = guard.MaximumLength(3);

		// Assert
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void Should_ThrowGuardException_When_ValueLengthIsGreaterThanMaximumLength()
	{
		// Arrange
		var guard = Guard.CheckIf("Value", "PropertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.MaximumLength(3).ThrowIfFailed());
	}
}

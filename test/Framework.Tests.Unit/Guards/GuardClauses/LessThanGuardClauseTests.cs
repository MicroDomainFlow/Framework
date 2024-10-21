using MDF.Framework.Extensions.Guards;
using MDF.Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class LessThanGuardClauseTests
{
	[Fact]
	public void Should_ReturnSuccessResult_When_ValueIsLessThanMaximumValue()
	{
		// Arrange
		var guard = Guard.CheckIf(5, "PropertyName");

		// Act
		var result = guard.LessThan(10);

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnFailureResult_When_ValueIsGreaterThanMaximumValue()
	{
		// Arrange
		var guard = Guard.CheckIf(15, "PropertyName");

		// Act
		var result = guard.LessThan(10);

		// Assert
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void Should_ThrowGuardException_When_ValueIsGreaterThanMaximumValueAndThrowIfFailedIsCalled()
	{
		// Arrange
		var guard = Guard.CheckIf(15, "PropertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.LessThan(10).ThrowIfFailed());
	}
}

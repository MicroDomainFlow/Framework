using MDF.Extensions.Guards;
using MDF.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class InclusiveBetweenGuardClauseTests
{
	[Fact]
	public void Should_ReturnSuccessfulResult_When_ValueIsBetweenMinimumAndMaximum()
	{
		// Arrange
		var guard = Guard.CheckIf(5, "Value");

		// Act
		guard.InclusiveBetween(1, 10);

		// Assert
		Assert.True(guard._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnFailedResult_When_ValueIsLessThanMinimum()
	{
		// Arrange
		var guard = Guard.CheckIf(5, "Value");

		// Act
		guard.InclusiveBetween(10, 20);

		// Assert
		Assert.True(guard._result.IsFailed);
	}

	[Fact]
	public void Should_ReturnFailedResult_When_ValueIsGreaterThanMaximum()
	{
		// Arrange
		var guard = Guard.CheckIf(5, "Value");

		// Act
		guard.InclusiveBetween(1, 4);

		// Assert
		Assert.True(guard._result.IsFailed);
	}

	[Fact]
	public void Should_Throw_GuardException_When_ResultIsFailed()
	{
		// Arrange
		var guard = Guard.CheckIf(5, "Value");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.InclusiveBetween(10, 20).ThrowIfFailed());
	}
}

using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class LessThanOrEqualGuardClauseTests
{
	[Fact]
	public void LessThanOrEqual_ShouldNotAddError_WhenValueIsLessThanOrEqualToMinimumValue()
	{
		// Arrange
		var guard = Guard.CheckIf(5, "PropertyName");

		// Act
		guard.LessThanOrEqual(10);

		// Assert
		Assert.True(guard._result.IsSuccess);
	}

	[Fact]
	public void LessThanOrEqual_ShouldAddError_WhenValueIsGreaterThanMinimumValue()
	{
		// Arrange
		var guard = Guard.CheckIf(15, "PropertyName");

		// Act
		guard.LessThanOrEqual(10);

		// Assert
		Assert.False(guard._result.IsSuccess);
		Assert.Contains("PropertyName", guard._result.Errors.First().Message);
	}

	[Fact]
	public void LessThanOrEqual_ShouldThrowGuardException_WhenValueIsGreaterThanMinimumValue_AndThrowIfFailedCalled()
	{
		// Arrange
		var guard = Guard.CheckIf(15, "PropertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.LessThanOrEqual(10).ThrowIfFailed());
	}
}

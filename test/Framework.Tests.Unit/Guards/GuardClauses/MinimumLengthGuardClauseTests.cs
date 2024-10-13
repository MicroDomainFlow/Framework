using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class MinimumLengthGuardClauseTests
{
	[Fact]
	public void MinimumLength_WithValidString_ShouldNotAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf("test", "propertyName");

		// Act
		guard.MinimumLength(3);

		// Assert
		Assert.True(guard._result.IsSuccess);
	}

	[Fact]
	public void MinimumLength_WithInvalidString_ShouldAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf("test", "propertyName");

		// Act
		guard.MinimumLength(10);

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains("propertyName", guard._result.Errors[0].Message);
	}

	[Fact]
	public void MinimumLength_WithValidCollection_ShouldNotAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf(new[] { 1, 2, 3 }, "propertyName");

		// Act
		guard.MinimumLength(2);

		// Assert
		Assert.True(guard._result.IsSuccess);
	}

	[Fact]
	public void MinimumLength_WithInvalidCollection_ShouldAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf(new[] { 1, 2, 3 }, "propertyName");

		// Act
		guard.MinimumLength(10);

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains("propertyName", guard._result.Errors[0].Message);
	}
}

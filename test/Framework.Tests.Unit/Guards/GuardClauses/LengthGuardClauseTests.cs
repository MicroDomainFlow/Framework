using MDF.Framework.Extensions.Guards;
using MDF.Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class LengthGuardClauseTests
{
	[Fact]
	public void Length_WithValidLength_ShouldNotAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf("test", "propertyName");

		// Act
		guard.Length(4);

		// Assert
		Assert.True(guard._result.IsSuccess);
	}

	[Fact]
	public void Length_WithInvalidLength_ShouldAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf("test", "propertyName");

		// Act
		guard.Length(10);

		// Assert
		Assert.False(guard._result.IsSuccess);
		Assert.Single(guard._result.Errors);
	}

	[Fact]
	public void Length_WithValidCollectionLength_ShouldNotAddErrorToResult()
	{
		// Arrange & Act
		var guard = Guard.CheckIf(new[] { 1, 2, 3 }, "propertyName")
			.Length(3);

		// Assert
		Assert.True(guard._result.IsSuccess);
	}

	[Fact]
	public void Length_WithInvalidCollectionLength_ShouldAddErrorToResult()
	{
		// Arrange
		var guard = Guard.CheckIf(new[] { 1, 2, 3 }, "propertyName");

		// Act
		guard.Length(5);

		// Assert
		Assert.False(guard._result.IsSuccess);
		Assert.Single(guard._result.Errors);
	}
}

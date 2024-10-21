using MDF.Framework.Extensions.Guards;
using MDF.Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class GreaterThanOrEqualGuardClauseTests
{
	[Fact]
	public void Should_ReturnSuccessResult_When_ValueIsGreaterThan_MinimumValue()
	{
		// Arrange & Act
		var result = Guard.CheckIf(10, "propertyName")
			.GreaterThanOrEqual(5);

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnSuccessResult_When_ValueIsEqualToMinimumValue()
	{
		// Arrange & Act
		var result = Guard.CheckIf(5, "propertyName")
			.GreaterThanOrEqual(5);


		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnFailureResult_When_ValueIsLessThanMinimumValue()
	{
		// Arrange & Act
		var result = Guard.CheckIf(3, "propertyName")
			.GreaterThanOrEqual(5);


		// Assert
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void Should_ThrowGuardException_When_ValueIsLessThanMinimumValue()
	{
		// Arrange
		var guard = Guard.CheckIf(3, "propertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.GreaterThanOrEqual(5).ThrowIfFailed());
	}
}

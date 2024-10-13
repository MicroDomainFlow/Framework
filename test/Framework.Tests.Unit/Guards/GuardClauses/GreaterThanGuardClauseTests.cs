using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class GreaterThanGuardClauseTests
{
	[Fact]
	public void GreaterThan_Should_ReturnSuccessfulResult_When_ValueIsGreaterThanMinimum()
	{
		// Arrange & Act
		var result = Guard.CheckIf(10, "Value")
			.GreaterThan(5);


		// Assert
		Assert.True(result._result.IsSuccess);
		Assert.False(result._result.IsFailed);
	}

	[Fact]
	public void GreaterThan_Should_ReturnFailedResult_When_ValueIsLessThanMinimum()
	{
		// Arrange & Act
		var result = Guard.CheckIf(3, "Value")
			.GreaterThan(5);

		// Assert
		Assert.False(result._result.IsSuccess);
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void GreaterThan_Should_ThrowGuardException_When_ValueIsLessThanMinimum()
	{
		// Arrange & Act
		var ex = Record.Exception(() => Guard.CheckIf(3, "Value")
			.GreaterThan(5).ThrowIfFailed());

		// Assert
		Assert.NotNull(ex);
	}
}

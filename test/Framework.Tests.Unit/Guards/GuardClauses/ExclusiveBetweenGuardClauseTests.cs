using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

public class ExclusiveBetweenGuardClauseTests
{
	[Fact]
	public void Should_ReturnGuardWithNoErrors_When_ValueIsExclusiveBetweenMinimumAndMaximum()
	{
		// Arrange & Act
		var result = Guard.CheckIf(5, "PropertyName").ExclusiveBetween(1, 10);

		// Assert
		Assert.True(result._result.IsSuccess);
		Assert.False(result._result.IsFailed);
	}

	[Fact]
	public void Should_ReturnGuardWithError_When_ValueIsNotExclusiveBetweenMinimumAndMaximum()
	{
		// Arrange & Act
		var result = Guard.CheckIf(15, "PropertyName")
			.ExclusiveBetween(1, 10);


		// Assert
		Assert.True(result._result.IsFailed);
		Assert.False(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ThrowGuardException_When_ValueIsNotExclusiveBetweenMinimumAndMaximumAndThrowIfFailedIsCalled()
	{
		// Arrange & Act
		var ex = Record.Exception(() => Guard.CheckIf(15, "PropertyName").ExclusiveBetween(1, 10).ThrowIfFailed());

		// Assert
		Assert.NotNull(ex);
	}
}

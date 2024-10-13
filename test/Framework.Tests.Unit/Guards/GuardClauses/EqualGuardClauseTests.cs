using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class EqualGuardClauseTests
{
	[Fact]
	public void Equal_WhenValueIsNotEqual_ThrowsException_ThrowIfFailed()
	{
		// Arrange
		var value = 5;
		var targetValue = 10;

		// Act & Assert
		Assert.Throws<GuardException>(() =>
		{
			Guard.CheckIf(value, "value").Equal(targetValue).ThrowIfFailed();
		});
	}

	[Fact]
	public void Equal_WhenValueIsNotEqual_ReturnsGuard_AsResult()
	{
		// Arrange
		var value = 5;
		var targetValue = 10;

		// Act
		var result = Guard.CheckIf(value, "value").Equal(targetValue);

		// Assert
		Assert.True(result._result.IsFailed);
		Assert.False(result._result.IsSuccess);
	}

	[Fact]
	public void Equal_WhenValueIsEqual_DoesNotThrowException_ThrowIfFailed()
	{
		// Arrange
		var value = 10;
		var targetValue = 10;


		// Act
		var ex = Record.Exception(() => Guard.CheckIf(value, "value").Equal(targetValue).ThrowIfFailed());

		// Assert
		Assert.Null(ex);
	}

	[Fact]
	public void Equal_WhenValueIsEqual_ReturnsGuard_AsResult()
	{
		// Arrange
		var value = 10;
		var targetValue = 10;

		// Act
		var result = Guard.CheckIf(value, "value").Equal(targetValue);

		// Assert
		Assert.True(result._result.IsSuccess);
		Assert.False(result._result.IsFailed);
	}

}

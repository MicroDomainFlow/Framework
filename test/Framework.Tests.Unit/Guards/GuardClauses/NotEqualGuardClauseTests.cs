using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class NotEqualGuardClauseTests
{
	[Fact]
	public void Should_ReturnSuccessfulResult_When_ValuesAreNotEqual()
	{
		// Arrange
		var guard = Guard.CheckIf("10", "propertyName");

		// Act
		var result = guard.NotEqual("20");

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnFailedResult_When_ValuesAreEqual()
	{
		// Arrange
		var guard = Guard.CheckIf(10, "propertyName");

		// Act
		var result = guard.NotEqual(10);

		// Assert
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void Should_ThrowGuardException_When_ValuesAreEqualAndThrowIfFailedCalled()
	{
		// Arrange
		var guard = Guard.CheckIf(10, "propertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.NotEqual(10).ThrowIfFailed());
	}
}

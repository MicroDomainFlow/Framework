using MDF.Framework.Extensions.Guards;
using MDF.Framework.Extensions.Guards.GuardClauses;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class MatchGuardClauseTests
{
	[Fact]
	public void Should_ReturnGuard_With_SuccessfulResult()
	{
		// Arrange
		var guard = Guard.CheckIf("Hello", "propertyName");

		// Act
		var result = guard.Match("^H.*$");

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ThrowGuardException_When_MatchFails()
	{
		// Arrange
		var guard = Guard.CheckIf("Hello", "propertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.Match("^W.*$").ThrowIfFailed());
	}
}

using MDF.Extensions.Guards;
using MDF.Extensions.Guards.GuardClauses;

using System.Collections;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class NotNullGuardClauseTests
{
	[Fact]
	public void Should_ReturnSuccessfulResult_When_ValueIsNotNull()
	{
		// Arrange
		var guard = Guard.CheckIf("test", "propertyName");

		// Act
		var result = guard.NotNull<string>();

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnFailedResult_When_ValueIsNull()
	{
		// Arrange
		var guard = Guard.CheckIf<int?>(null, "propertyName");

		// Act
		var result = guard.NotNull<int?>();

		// Assert
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void Should_ThrowGuardException_When_ValueIsNull()
	{
		// Arrange
		var guard = Guard.CheckIf<ICollection>(null, "propertyName");

		// Act & Assert
		Assert.Throws<GuardException>(() => guard.NotNull<ICollection>().ThrowIfFailed());
	}
}

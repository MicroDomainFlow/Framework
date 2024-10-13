using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

using Resources.Common.FormattedMessages;

namespace Framework.Tests.Unit.Guards.GuardClauses;

public class NotEmptyGuardClauseTests
{
	[Fact]
	public void NotEmpty_Should_AddError_When_PropertyName_Is_NullOrEmpty()
	{
		// Arrange
		var guard = Guard.CheckIf<string>(null, "");
		var errorMessage = ValidationMessages.Required("");

		// Act
		guard.NotEmpty<string>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}

	[Fact]
	public void NotEmpty_Should_AddError_When_Value_Is_Null()
	{
		// Arrange
		var guard = Guard.CheckIf<int?>(null, "PropertyName");
		var errorMessage = ValidationMessages.Required("PropertyName");

		// Act
		guard.NotEmpty<int?>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}

	[Fact]
	public void NotEmpty_Should_AddError_When_Value_Is_Empty_Collection()
	{
		// Arrange
		var guard = Guard.CheckIf(new List<int>(), "PropertyName");
		var errorMessage = ValidationMessages.Required("PropertyName");

		// Act
		guard.NotEmpty<List<int>?>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}

	[Fact]
	public void NotEmpty_Should_AddError_When_Value_Is_Empty_Enumerable()
	{
		// Arrange
		var guard = Guard.CheckIf(Enumerable.Empty<int>(), "PropertyName");
		var errorMessage = ValidationMessages.Required("PropertyName");

		// Act
		guard.NotEmpty<IEnumerable<int>>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}

	[Fact]
	public void NotEmpty_Should_AddError_When_Value_Is_NullOrWhiteSpace_String()
	{
		// Arrange
		var guard = Guard.CheckIf("   ", "PropertyName");
		var errorMessage = ValidationMessages.Required("PropertyName");

		// Act
		guard.NotEmpty<string>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}

	[Fact]
	public void NotEmpty_Should_AddError_When_Value_Is_Default_Generic_Type()
	{
		// Arrange
		var guard = Guard.CheckIf(default(int), "PropertyName");
		var errorMessage = ValidationMessages.Required("PropertyName");

		// Act
		guard.NotEmpty<int>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}
	[Fact]
	public void Should_AddError_When_ValueIsDefaultGenericTypeWithCustomEqualityComparer()
	{
		// Arrange
		var guard = Guard.CheckIf(default(int), "PropertyName");
		var errorMessage = ValidationMessages.Required("PropertyName");

		// Act
		guard.NotEmpty<int>(new CustomEqualityComparer());

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(errorMessage, guard._result.Errors[0].Message);
	}
}

public class CustomEqualityComparer : IEqualityComparer<int>
{
	public bool Equals(int x, int y)
	{
		return x == y;
	}

	public int GetHashCode(int obj)
	{
		return obj.GetHashCode();
	}
}

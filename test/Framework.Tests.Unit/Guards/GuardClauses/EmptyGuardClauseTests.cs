using MDF.Extensions.Guards;
using MDF.Extensions.Guards.GuardClauses;

using System.Collections;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class EmptyGuardClauseTests
{
	[Theory]
	[InlineData(null, typeof(GuardException))]
	[InlineData("", typeof(GuardException))]
	public void Should_ThrowException_When_MessageIsNullOrNotDefaultValue(string? message, Type exceptionType)
	{
		// Arrange
		string value = "some value";
		string? inputMessage = message;

		// Act & Assert
		Assert.Throws(exceptionType, () => Guard.CheckIf(value, inputMessage).Empty<string>().ThrowIfFailed());
	}

	[Fact]
	public void Should_ReturnOk_When_ValueIsNull()
	{
		// Arrange
		string? value = null;

		// Act
		var ex = Record.Exception(() => Guard.CheckIf(value, nameof(value)).Empty().ThrowIfFailed());

		// Assert
		Assert.Null(ex);

	}

	[Fact]
	public void Should_ReturnOk_When_ValueIsEmptyString()
	{
		// Arrange
		string value = "";

		// Act
		var result = Guard.CheckIf(value, nameof(value)).Empty<string>();

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnOk_When_ValueIsWhiteSpaceString()
	{
		// Arrange
		string value = "   ";

		// Act
		var result = Guard.CheckIf(value, nameof(value)).Empty<string>();

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnOk_When_ValueIsCollectionAndIsEmpty()
	{
		// Arrange
		ICollection value = new List<int>();

		// Act
		var result = Guard.CheckIf(value, nameof(value)).Empty();

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ReturnOk_When_ValueIsEnumerableAndIsEmpty()
	{
		// Arrange
		IEnumerable value = new List<int>();

		// Act
		var result = Guard.CheckIf(value, nameof(value)).Empty();

		// Assert
		Assert.True(result._result.IsSuccess);
	}

	[Fact]
	public void Should_ThrowException_When_ValueIsNotDefaultValue()
	{
		// Arrange
		int value = 10;

		// Act & Assert
		Assert.Throws<GuardException>(() => Guard.CheckIf(value, nameof(value)).Empty<int>().ThrowIfFailed());
	}

	[Fact]
	public void Should_Fail_When_ValueIsNotDefaultValue()
	{
		// Arrange
		int value = 10;

		// Act
		var result = Guard.CheckIf(value, nameof(value)).Empty<int>();
		// Assert
		Assert.False(result._result.IsSuccess);
		Assert.True(result._result.IsFailed);
	}

	[Fact]
	public void Should_ThrowException_When_ValuesIsNotDefaultValueWithCustomIEqualityComparer()
	{
		//Arrange
		int value = 10;

		//Act
		IntComparer intComparer = new IntComparer();
		var ex = Record.Exception(() => Guard.CheckIf(value, nameof(value)).Empty<int>(intComparer).ThrowIfFailed());

		//Assertion
		Assert.NotNull(ex);

	}
	[Fact]
	public void Should_Fail_When_ValuesIsNotDefaultValueWithCustomIEqualityComparer()
	{
		//Arrange
		int value = 10;

		//Act
		IntComparer intComparer = new IntComparer();
		var result = Guard.CheckIf(value, nameof(value)).Empty<int>(intComparer);

		//Assertion
		Assert.False(result._result.IsSuccess);
		Assert.True(result._result.IsFailed);

	}
}

public class IntComparer : IEqualityComparer<int>
{
	public bool Equals(int x, int y)
	{
		// Implement your equality comparison logic here
		// For example, comparing the integers directly
		return x == y;
	}

	public int GetHashCode(int obj)
	{
		// Implement your hashing logic here
		// For a simple case with integers, you can just return the int itself
		return obj.GetHashCode();
	}
}

﻿using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

using Resources.Common.FormattedMessages;

namespace Framework.Tests.Unit.Guards.GuardClauses;
public class NullGuardClauseTests
{
	[Fact]
	public void Should_AddError_When_ValueIsNotNull()
	{
		// Arrange
		var guard = Guard.CheckIf("value", "propertyName");
		var message = ValidationMessages.Null("propertyName");
		// Act
		guard.Null<string>();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(message, guard._result.Errors[0].Message);
	}

	[Fact]
	public void Should_NotAddError_When_ValueIsNull()
	{
		// Arrange
		var guard = Guard.CheckIf<int?>(null, "propertyName");

		// Act
		guard.Null();

		// Assert
		Assert.False(guard._result.IsFailed);
	}

	[Fact]
	public void Should_AddError_When_PropertyNameIsNullOrEmpty()
	{
		// Arrange
		var guard = Guard.CheckIf<int?>(null, "");
		var message = ValidationMessages.Required("");

		// Act
		guard.Null();

		// Assert
		Assert.True(guard._result.IsFailed);
		Assert.Contains(message, guard._result.Errors[0].Message);
	}
}

using FluentResults;

using MDF.Framework.SeedWork;

namespace Framework.Tests.Unit;

public class BaseValueObjectTests
{
	class MyTestObject : BaseValueObject<string>
	{
		protected const byte Min = 5;
		private const byte Max = 15;
		public MyTestObject(string value) : base(value)
		{
		}

		public static Result<MyTestObject> Create(string? input)
		{
			Result<MyTestObject> result = new();

			if (string.IsNullOrWhiteSpace(input))
			{
				result.WithError($"{nameof(MyTestObject)}Can not be null");
				return result;
			}
			if (input.Length < Min || input.Length > Max)
			{
				result.WithError($"{nameof(MyTestObject)} must be between {Min} and {Max} characters.");
			}

			var returnValue = new MyTestObject(input);
			result.WithValue(returnValue);
			return result;
		}
	}

	class MyTestMultiObjects : BaseValueObject<int>
	{
		protected const byte Min = 0;
		private const byte Max = 255;

		public int Green { get; }
		public int Blue { get; }
		public MyTestMultiObjects(int red, int green, int blue) : base(value: red)
		{
			Green = green;
			Blue = blue;
		}

		public static Result<MyTestMultiObjects> Create(int? red, int? green, int? blue)
		{
			Result<MyTestMultiObjects> result = new();
			if (red == null || green == null || blue == null)
			{
				result.WithError($"{nameof(MyTestObject.Value)}Can not be null");
				return result;
			}
			if (red.Value < Min || green.Value < Min || blue.Value < Min)
			{
				if (red.Value < Min) red = Min;
				if (green.Value < Min) green = Min;
				if (blue.Value < Min) blue = Min;
			}
			if (red.Value > Max || green.Value > Max || blue.Value > Max)
			{
				if (red.Value > Max) red = Max;
				if (green.Value > Max) green = Max;
				if (blue.Value > Max) blue = Max;
			}

			var returnValue = new MyTestMultiObjects((int)red, (int)green, (int)blue);
			result.WithValue(returnValue);
			return result;
		}
		protected override IEnumerable<object?> GetEqualityComponents()
		{
			yield return Value;
			yield return Green;
			yield return Blue;
		}
	}

	[Fact]
	public void Should_CreatedCorrectValueObject_When_UsingBaseValueObjectClassWithCorrectValue()
	{
		//Arrange
		string input = "1234567890";

		//Act
		var result = MyTestObject.Create(input);
		var result2 = MyTestObject.Create(input);

		//Assertion
		Assert.True(result.Value == result2.Value);
		Assert.False(result.IsFailed);
		Assert.True(result.IsSuccess);
		Assert.Empty(result.Errors);
	}

	[Fact]
	public void Should_CreatedCorrectValueObject_When_AddMoreValues()
	{
		//Arrange
		int red = -20;
		int green = 155;
		int blue = 266;

		//Act
		var result = MyTestMultiObjects.Create(red, green, blue);
		var result2 = MyTestMultiObjects.Create(red, green, blue);

		//Assertion
		Assert.False(result.IsFailed);
		Assert.Equal(0, result.Value.Value);
		Assert.Equal(green, result.Value.Green);
		Assert.Equal(255, result.Value.Blue);
		Assert.True(result.Value == result2.Value);
		Assert.True(result.Value.Green == result2.Value.Green);
		Assert.Empty(result.Errors);
		//		Assert.Empty(result.ErrorsMessages); ایا باید به کتابخانه fluentresult به صورت اکستنش متد اضافه کنم؟
		Assert.Empty(result.Successes);
		//Assert.Empty(result.SuccessesMessages);//اینها قبلا در infoinaResult بودند که به Result کتابخانه اصلی اضافه کردم
	}

	[Fact]
	public void Should_ReturnErrorMessage_When_PassNullArgument()
	{
		//Arrange
		string? input = null;
		string errorMessage = $"{nameof(MyTestObject)}Can not be null";
		//Act
		var result = MyTestObject.Create(input);

		//Assertion
		Assert.True(result.IsFailed);
		Assert.False(result.IsSuccess);
		Assert.Single(result.Errors);
		Assert.Equal(errorMessage, result.Errors.First().Message);
	}

}
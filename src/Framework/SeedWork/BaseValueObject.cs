namespace Framework.SeedWork;
public abstract class BaseValueObject<TValue> : ValueObject
{
	#region Properties
	public TValue? Value { get; }
	#endregion

	#region Constructors and Factories
	protected BaseValueObject() : base() // for ef core
	{
	}

	protected BaseValueObject(TValue? value) : this()
	{
		Value = value;
	}
	#endregion

	#region Operator Overloading
	/// <summary>
	/// این متد یک تبدیل از اشیاء با نوع داده های مختلف به یک نوع داده خاص انجام می دهد.
	/// </summary>
	/// <param name="obj">اشیاءی که نوع داده های مختلف آن ها باید به یک نوع داده خاص تبدیل شوند.</param>
	/// <returns>نوع داده خاصی که از اشیاء با نوع داده های مختلف تبدیل شده است.</returns>
	public static explicit operator TValue?(BaseValueObject<TValue?> obj) => obj.Value;
	/// <summary>
	/// این متد یک نمونه از کلاس BaseObjectValue با استفاده از ارث بری از پارامتر TValue ایجاد می کند.
	/// </summary>
	/// <typeparam name="TValue">نوع مقدار ورودی</typeparam>
	/// <typeparam name="T">نوع کلاس برگشتی</typeparam>
	/// <param name="value">مقدار ورودی</param>
	/// <returns>یک نمونه از کلاس BaseObjectValue</returns>
	public static implicit operator BaseValueObject<TValue>?(TValue value) => Activator.CreateInstance(typeof(BaseValueObject<TValue>), value) as BaseValueObject<TValue>;
	#endregion

	#region Methods
	/// <summary>
	/// این متد برای تبدیل مقدار فیلد Value کلاس به یک رشته برمیگرداند.
	/// </summary>
	/// <returns>یک رشته از مقدار Value</returns>
	public override string ToString() => Value?.ToString() ?? "----";


	protected override IEnumerable<object?> GetEqualityComponents()
	{
		yield return Value;
	}
	#endregion
}
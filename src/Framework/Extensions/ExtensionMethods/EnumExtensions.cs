using System.ComponentModel;
using System.Numerics;

namespace Framework.Extensions.ExtensionMethods;
public static class EnumExtensions
{
	public static string ToNumericalValueString(this Enum enumValue)
	{
		return ((int)(object)enumValue).ToString();
	}

	public static string? ToNumericalValueString<T>(this Enum enumValue) where T : INumber<T>
	{
		return ((T)(object)enumValue).ToString();
	}
	public static int ToNumericalValue(this Enum enumValue)
	{
		return ((int)(object)enumValue);
	}

	public static T ToNumericalValue<T>(this Enum enumValue) where T : INumber<T>
	{
		return ((T)(object)enumValue);
	}

	/// <summary>
	/// برای دریافت توضیحات یک ویژگی از enum اگر [Description] داشته باشد از این متد استفاده می‌شود.
	/// </summary>
	/// <param name="enumValue">مقداری که قرار است توضحیات آن دریافت شود</param>
	/// <returns>متن داخل [Description] در صورتی که وجود داشته باشد و در غیراین صورت عنوان enums ارسال شده</returns>
	public static string GetEnumDescription(this Enum enumValue)
	{
		var memberInfo = enumValue.GetType().GetField(enumValue.ToString());
		var attributes = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
		var description = attributes != null ? ((DescriptionAttribute)attributes.FirstOrDefault()).Description : enumValue.ToString();
		return description;
	}
}

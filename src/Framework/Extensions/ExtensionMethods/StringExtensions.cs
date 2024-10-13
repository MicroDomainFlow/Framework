namespace Framework.Extensions.ExtensionMethods;

public static class StringExtensions
{
	static StringExtensions()
	{
	}

	/// <summary>
	/// این متد یک رشته را برای پاک کردن فاصله های اضافی و تریم کردن آن بررسی می کند و رشته تصحیح شده را برمی گرداند.
	/// </summary>
	/// <param name="text">رشته ای که نیاز به تصحیح دارد</param>
	/// <returns>رشته تصحیح شده</returns>
	public static string? Fix(this string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}

		text =
			text.Trim();

		while (text.Contains("  "))
		{
			text =
				text.Replace("  ", " ");
		}

		return text;
	}
}

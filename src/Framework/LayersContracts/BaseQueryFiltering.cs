using Gridify;

namespace MDF.Framework.LayersContracts;
/// <summary>
/// این کلاس نمایانگر ساختار نتیجه پایه برای عملیات پرس‌وجو است.
/// این کلاس شامل ویژگی‌هایی برای مدیریت صفحه‌بندی، فیلتر کردن و مرتب‌سازی نتایج برای پرس‌وجوهای مبتنی بر گرید می‌باشد.
/// </summary>
public record BaseQueryFiltering : IGridifyQuery
{
	/// <summary>
	/// شماره صفحه فعلی برای صفحه‌بندی را دریافت یا تنظیم می‌کند.
	/// </summary>
	public int Page { get; set; } = 1;

	/// <summary>
	/// تعداد آیتم‌ها در هر صفحه برای صفحه‌بندی را دریافت یا تنظیم می‌کند.
	/// </summary>
	public int PageSize { get; set; } = 20;

	/// <summary>
	/// شرایط فیلتر برای پرس‌وجو را دریافت یا تنظیم می‌کند.
	/// این ویژگی اجازه می‌دهد تا نتایج با توجه به شرایط خاص محدود شوند.
	/// </summary>
	public string? Filter { get; set; }

	/// <summary>
	/// شرایط مرتب‌سازی برای پرس‌وجو را دریافت یا تنظیم می‌کند.
	/// این ویژگی مشخص می‌کند که نتایج بر اساس چه فیلدهایی مرتب شوند.
	/// </summary>
	public string? OrderBy { get; set; }
}


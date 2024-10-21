using MDF.SeedWork;

using System.Linq.Expressions;

namespace MDF.Contract.Persistence.Commands;
/// <summary>
/// در صورتی که داده‌ها به صورت عادی ذخیره سازی شوند از این Interface جهت تعیین اعمال اصلی موجود در بخش ذخیره سازی داده‌ها استفاده می‌شود.
/// </summary>
/// <typeparam name="TEntity">کلاسی که جهت ذخیره سازی انتخاب می‌شود</typeparam>
public interface ICommandRepository<TEntity> : IUnitOfWork
	where TEntity : AggregateRoot<TEntity>
{
	/// <summary>
	/// یک شی را با شناسه حذف می کند
	/// </summary>
	/// <param name="id">شناسه</param>
	void DeleteBy(Guid id);

	/// <summary>
	/// حذف یک شی به همراه تمامی فرزندان آن را انجام می دهد
	/// </summary>
	/// <param name="id">شناسه</param>
	void DeleteGraphBy(Guid id);

	/// <summary>
	/// یک شی را دریافت کرده و از دیتابیس حذف می‌کند
	/// </summary>
	/// <param name="entity"></param>
	void DeleteBy(TEntity entity);

	/// <summary>
	/// بروزرسانی یک موجودیت با استفاده از موجودیت ورودی را انجام می‌دهد.
	/// زمانی که از Unit Of Work استفاده میکنید برای بروزرسانی موجودیت از این متد استفاده کنید
	/// </summary>
	void UpdateBy(TEntity entity);

	/// <summary>
	/// بروزرسانی یک مجموعه از موجودیت‌ها با استفاده از مجموعه ورودی را انجام می‌دهد.
	/// زمانی که از Unit Of Work استفاده میکنید برای بروزرسانی موجودیت از این متد استفاده کنید
	/// </summary>
	void UpdateBy(IEnumerable<TEntity> entities);

	/// <summary>
	/// داده‌های جدید را به دیتابیس اضافه می‌کند
	/// </summary>
	/// <param name="entity">نمونه داده‌ای که باید به دیتابیس اضافه شود.</param>
	void InsertBy(TEntity entity);

	/// <summary>
	/// داده‌های جدید را به دیتابیس اضافه می‌کند
	/// </summary>
	/// <param name="entity">نمونه داده‌ای که باید به دیتابیس اضافه شود.</param>
	/// <param name="cancellationToken"></param>
	Task InsertByAsync(TEntity entity, CancellationToken cancellationToken = default);

	/// <summary>
	/// یک شی را با شناسه از دیتابیس یافته و بازگشت می‌دهد.
	/// </summary>
	/// <param name="id">شناسه شی مورد نیاز</param>
	/// <returns>نمونه ساخته شده از شی</returns>
	TEntity? GetBy(Guid id);
	Task<TEntity?> GetByAsync(Guid id, CancellationToken cancellationToken = default);
	TEntity? GetGraphBy(Guid id);
	Task<TEntity?> GetGraphByAsync(Guid id, CancellationToken cancellationToken = default);
	bool Exists(Expression<Func<TEntity, bool>> expression);
	Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
}

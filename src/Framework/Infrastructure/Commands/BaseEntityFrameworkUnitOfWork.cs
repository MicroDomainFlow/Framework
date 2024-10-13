using Framework.Contract.Persistence.Commands;

namespace Framework.Infrastructure.Commands;
/// <summary>
/// اگر از چند ریپازیتوری استفاده میکنید باید از این یونیت آو ورک استفاده کنید
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public abstract class BaseEntityFrameworkUnitOfWork<TDbContext> : IUnitOfWork, IAsyncDisposable where TDbContext : BaseCommandDbContext
{
	protected readonly TDbContext DbContext;

	public BaseEntityFrameworkUnitOfWork(TDbContext dbContext)
	{
		DbContext = dbContext;
	}

	public bool IsDisposed { get; protected set; }

	public void BeginTransaction()
	{
		DbContext.BeginTransaction();
	}

	public int Commit()
	{
		var result = DbContext.SaveChanges();
		return result;
	}

	public async Task<int> CommitAsync()
	{
		var result = await DbContext.SaveChangesAsync();
		return result;
	}

	public async Task<int> CommitAsync(CancellationToken cancellationToken)
	{
		var result = await DbContext.SaveChangesAsync(cancellationToken);
		return result;
	}

	public void CommitTransaction()
	{
		DbContext.CommitTransaction();
	}

	public void RollbackTransaction()
	{
		DbContext.RollbackTransaction();
	}

	public void Dispose()
	{
		if (DbContext is IDisposable dbContextDisposable)
			dbContextDisposable.Dispose();
		else
			_ = DbContext.DisposeAsync().AsTask();
	}

	public ValueTask DisposeAsync()
	{
		return DbContext.DisposeAsync();
	}
}


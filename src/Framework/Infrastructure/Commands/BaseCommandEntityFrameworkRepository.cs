using MDF.Framework.LayersContracts.Persistence.Commands;
using MDF.Framework.SeedWork;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace MDF.Framework.Infrastructure.Commands;
/// <summary>
/// جهت استفاده در CommandRepository ها.
/// اگر فقط از یک ریپازیتوری استفاده میکنید این ریپازیتوری خود شامل یونیت آو ورک میباشد و نیازی به استفاده از کلاس BaseEntityFrameworkUnitOfWork نمی باشد.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDbContext"></typeparam>
public class BaseCommandEntityFrameworkRepository<TEntity, TDbContext> : ICommandRepository<TEntity>, IUnitOfWork, IAsyncDisposable where TEntity : AggregateRoot<TEntity>
	where TDbContext : BaseCommandDbContext

{

	protected readonly TDbContext DbContext;

	public BaseCommandEntityFrameworkRepository(TDbContext dbContext)
	{
		DbContext = dbContext;
	}



	public void DeleteBy(Guid id)
	{
		var entity = DbContext.Set<TEntity>().Find(id);
		if (entity is not null)
			DbContext.Set<TEntity>().Remove(entity);
	}

	public void DeleteBy(TEntity entity)
	{
		DbContext.Set<TEntity>().Remove(entity);
	}

	public void DeleteGraphBy(Guid id)
	{
		var entity = GetGraphBy(id);
		if (entity is not null && !entity.Id.Equals(default))
			DbContext.Set<TEntity>().Remove(entity);
	}

	#region Update

	public void UpdateBy(TEntity entity)
	{
		DbContext.Set<TEntity>().Update(entity);
	}

	public void UpdateBy(IEnumerable<TEntity> entities)
	{
		DbContext.Set<TEntity>().UpdateRange(entities);
	}

	#endregion

	#region insert

	public void InsertBy(TEntity entity)
	{
		DbContext.Set<TEntity>().Add(entity);
	}

	public async Task InsertByAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
	}
	#endregion

	#region Get single item with graph
	public TEntity? GetBy(Guid id)
	{
		var graphPath = DbContext.GetIncludePaths(typeof(TEntity));
		IQueryable<TEntity>? query = DbContext.Set<TEntity>().AsQueryable();
		var enumerable = graphPath.ToList();
		var temp = enumerable.ToList();
		foreach (var item in enumerable)
		{
			query = query.Include(item);
		}

		return query.FirstOrDefault(e => e.Id == id);
	}

	public Task<TEntity?> GetByAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var includePath = DbContext.GetIncludePaths(typeof(TEntity));
		IQueryable<TEntity>? query = DbContext.Set<TEntity>().AsQueryable();
		foreach (var item in includePath)
		{
			query = query.Include(item);
		}

		return query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
	}

	#endregion

	#region Get single item with graph
	public TEntity? GetGraphBy(Guid id)
	{
		var graphPath = DbContext.GetIncludePaths(typeof(TEntity));
		var query = DbContext.Set<TEntity>().AsQueryable();
		var enumerable = graphPath as string[] ?? graphPath.ToArray();
		var temp = enumerable.ToList();
		foreach (var item in enumerable)
		{
			query = query.Include(item);
		}
		return query.FirstOrDefault(c => c.Id.Equals(id));
	}

	public Task<TEntity?> GetGraphByAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var graphPath = DbContext.GetIncludePaths(typeof(TEntity));
		IQueryable<TEntity> query = DbContext.Set<TEntity>().AsQueryable();
		foreach (var item in graphPath)
		{
			query = query.Include(item);
		}
		return query.FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
	}
	#endregion

	#region Exists
	public bool Exists(Expression<Func<TEntity, bool>> expression)
	{
		return DbContext.Set<TEntity>().Any(expression);
	}

	public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
	{
		return DbContext.Set<TEntity>().AnyAsync(expression, cancellationToken);
	}
	#endregion

	#region Transaction management
	public int Commit()
	{
		return DbContext.SaveChanges();
	}

	public Task<int> CommitAsync()
	{
		return DbContext.SaveChangesAsync();
	}
	public Task<int> CommitAsync(CancellationToken cancellationToken)
	{
		return DbContext.SaveChangesAsync(cancellationToken);
	}

	public bool IsDisposed { get; protected set; }

	public void BeginTransaction()
	{
		DbContext.BeginTransaction();
	}

	public void CommitTransaction()
	{
		DbContext.CommitTransaction();
	}
	public void RollbackTransaction()
	{
		DbContext.RollbackTransaction();
	}

	#endregion

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
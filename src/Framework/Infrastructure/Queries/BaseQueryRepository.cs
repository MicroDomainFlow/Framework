using Framework.Contract.Persistence.Queries;

namespace Framework.Infrastructure.Queries;
public class BaseQueryRepository<TDbContext> : IQueryRepository
	where TDbContext : BaseQueryDbContext
{
	protected readonly TDbContext DbContext;
	public BaseQueryRepository(TDbContext dbContext)
	{
		DbContext = dbContext;
	}
}

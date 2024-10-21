using MDF.Contract.Persistence.Queries;

namespace MDF.Infrastructure.Queries;
public class BaseQueryRepository<TDbContext> : IQueryRepository
	where TDbContext : BaseQueryDbContext
{
	protected readonly TDbContext DbContext;
	public BaseQueryRepository(TDbContext dbContext)
	{
		DbContext = dbContext;
	}
}

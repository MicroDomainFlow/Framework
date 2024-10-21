using MDF.Framework.LayersContracts.Persistence.Queries;

namespace MDF.Framework.Infrastructure.Queries;
public class BaseQueryRepository<TDbContext> : IQueryRepository
	where TDbContext : BaseQueryDbContext
{
	protected readonly TDbContext DbContext;
	public BaseQueryRepository(TDbContext dbContext)
	{
		DbContext = dbContext;
	}
}

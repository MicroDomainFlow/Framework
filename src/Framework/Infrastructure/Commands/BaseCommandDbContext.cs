using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

using System.Globalization;

namespace Framework.Infrastructure.Commands;
public abstract class BaseCommandDbContext : DbContext
{
	protected IDbContextTransaction Transaction;

	protected BaseCommandDbContext(DbContextOptions options) : base(options)
	{

	}

	protected BaseCommandDbContext()
	{
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
	public void BeginTransaction()
	{
		Transaction = Database.BeginTransaction();
	}

	public void RollbackTransaction()
	{
		if (Transaction == null)
		{
			throw new NullReferenceException("Please call `BeginTransaction()` method first.");
		}
		Transaction.Rollback();
	}

	public void CommitTransaction()
	{
		if (Transaction == null)
		{
			throw new NullReferenceException("Please call `BeginTransaction()` method first.");
		}
		Transaction.Commit();
	}

	public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
	{
		var value = Entry(entity).Property(propertyName).CurrentValue;
		return value != null
			? (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)
			: default;
	}

	public object GetShadowPropertyValue(object entity, string propertyName)
	{
		return Entry(entity).Property(propertyName).CurrentValue;
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		//	builder.AddCommonShadowProperties();
	}
	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		//configurationBuilder.UseDateTimeAsUtcConversion();
		//configurationBuilder.UseNullableDateTimeAsUtcConversion();
	}

	public IEnumerable<string> GetIncludePaths(Type clrEntityType)
	{
		var entityType = Model.FindEntityType(clrEntityType);
		var includedNavigations = new HashSet<INavigation>();
		var stack = new Stack<IEnumerator<INavigation>>();
		while (true)
		{
			var entityNavigations = new List<INavigation>();
			foreach (var navigation in entityType.GetNavigations())
			{
				if (includedNavigations.Add(navigation))
					entityNavigations.Add(navigation);
			}
			if (entityNavigations.Count == 0)
			{
				if (stack.Count > 0)
					yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
			}
			else
			{
				foreach (var navigation in entityNavigations)
				{
					var inverseNavigation = navigation.Inverse;
					if (inverseNavigation != null)
						includedNavigations.Add(inverseNavigation);
				}
				stack.Push(entityNavigations.GetEnumerator());
			}
			while (stack.Count > 0 && !stack.Peek().MoveNext())
				stack.Pop();
			if (stack.Count == 0) break;
			entityType = stack.Peek().Current.TargetEntityType;
		}
	}
}
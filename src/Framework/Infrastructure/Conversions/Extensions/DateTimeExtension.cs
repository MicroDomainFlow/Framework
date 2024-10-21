using MDF.Extensions.Converters;
using MDF.SeedWork;

using Microsoft.EntityFrameworkCore;

namespace MDF.Infrastructure.Conversions.Extensions;
public static class DateTimeExtension
{
	public static ModelConfigurationBuilder UseDateTimeAsUtcConversion(this ModelConfigurationBuilder modelConfigurationBuilder)
	{
		modelConfigurationBuilder.Properties<DateTime>().HaveConversion<DateTimeAsUtcValueConverter>();
		return modelConfigurationBuilder;
	}

	public static ModelConfigurationBuilder UseNullableDateTimeAsUtcConversion(this ModelConfigurationBuilder modelConfigurationBuilder)
	{
		modelConfigurationBuilder.Properties<DateTime?>().HaveConversion<NullableDateTimeAsUtcValueConverter>();
		return modelConfigurationBuilder;
	}
	public static ModelBuilder UseDateTimeAsUtcPropertyConversion(this ModelBuilder modelBuilder, string propertyName)
	{
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			var dateProperty = entityType.FindProperty(propertyName);
			if (dateProperty != null && dateProperty.ClrType == typeof(DateTime))
			{
				dateProperty.SetValueConverter(new DateTimeAsUtcValueConverter());
			}
		}
		return modelBuilder;
	}

	public static ModelBuilder UseNullableDateTimeAsUtcPropertyConversion(this ModelBuilder modelBuilder, string propertyName)
	{
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			var dateProperty = entityType.FindProperty(propertyName);
			if (dateProperty != null && dateProperty.ClrType == typeof(DateTime?))
			{
				dateProperty.SetValueConverter(new NullableDateTimeAsUtcValueConverter());
			}
		}
		return modelBuilder;
	}
	public static ModelBuilder UseDateTimeAsUtcPropertyConversion<TEntity>(this ModelBuilder modelBuilder, string propertyName) where TEntity : class, IEntity
	{
		modelBuilder.Entity<TEntity>()
			.Property(e => EF.Property<DateTime>(e, propertyName))
			.HasConversion<DateTimeAsUtcValueConverter>();
		return modelBuilder;
	}

	public static ModelBuilder UseNullableDateTimeAsUtcPropertyConversion<TEntity>(this ModelBuilder modelBuilder, string propertyName) where TEntity : class, IEntity
	{
		modelBuilder.Entity<TEntity>()
			.Property(e => EF.Property<DateTime?>(e, propertyName))
			.HasConversion<NullableDateTimeAsUtcValueConverter>();

		return modelBuilder;
	}
}

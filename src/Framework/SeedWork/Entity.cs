using FluentResults;

namespace MDF.Framework.SeedWork;
public abstract class Entity : IEntity
{
	public readonly Result Result = new();

	#region Static Member(s)
	public static bool operator ==(Entity leftObject, Entity rightObject)
	{
		if (leftObject is null && rightObject is null)
		{
			return true;
		}

		if (leftObject is null && rightObject is not null)
		{
			return false;
		}

		if (leftObject is not null && rightObject is null)
		{
			return false;
		}

		return leftObject.Equals(rightObject);
	}
	public static bool operator !=(Entity leftObject, Entity rightObject)
	{
		return !(leftObject == rightObject);
	}
	#endregion /Static Member(s)

	protected Entity() : base()
	{
		Id = Guid.CreateVersion7();
	}

	// **********
	public Guid Id { get; private set; }
	//Utilities
	public void FromString(string value) => this.Id = new Guid(value);
	public void FromGuid(Guid value) => this.Id = value;
	public static explicit operator string(Entity entity) => entity.Id.ToString();
	public static implicit operator Guid(Entity entity) => entity.Id;
	// **********
	int? _requestedHashCode;

	public bool IsTransient()
	{
		return Id == default;
	}

	public override bool Equals(object anotherObject)
	{
		if (anotherObject is null)
		{
			return false;
		}

		if (anotherObject is not Entity)
		{
			return false;
		}

		if (ReferenceEquals(this, anotherObject))
		{
			return true;
		}

		Entity anotherEntity = anotherObject as Entity;

		// For EF Core!
		if (GetRealType() != anotherEntity.GetRealType())
		{
			return false;
		}

		if (GetType() == anotherEntity.GetType())
		{
			if (IsTransient() || anotherEntity.IsTransient())
			{
				return false;
			}
			else
			{
				return Id == anotherEntity.Id;
			}
		}

		return false;
	}

	public override int GetHashCode()
	{
		if (IsTransient() == false)
		{
			if (_requestedHashCode.HasValue == false)
			{
				_requestedHashCode = Id.GetHashCode() ^ 31;
			}

			// XOR for random distribution. See:
			// https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
			return _requestedHashCode.Value;
		}
		else
		{
			return base.GetHashCode();
		}
	}

	/// <summary>
	/// For EF Core!
	/// </summary>
	private Type GetRealType()
	{
		Type type = GetType();

		if (type.ToString().Contains("Castle.Proxies."))
		{
			return type.BaseType;
		}

		return type;
	}
}
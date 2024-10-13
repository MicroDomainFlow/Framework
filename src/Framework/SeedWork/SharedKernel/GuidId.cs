using FluentResults;

using Framework.Extensions.Guards;
using Framework.Extensions.Guards.GuardClauses;

using Resources.Common;
using Resources.Common.FormattedMessages;

namespace Framework.SeedWork.SharedKernel;
public class GuidId : BaseValueObject<Guid?>
{
	public const byte FixLength = 36;

	private GuidId()
	{

	}
	private GuidId(Guid? value) : base(value)
	{
	}

	public static Result<GuidId> Create(Guid? id)
	{
		Result<GuidId> result = new();
		//استفاه از گارد
		var guardResult = Guard.CheckIf(id, DataDictionary.Id)
			.NotNull()
			.NotEmpty()
			.Length(FixLength);
		//			.AsResult();

		if (guardResult._result.IsFailed)
		{
			return result.WithErrors(guardResult._result.Errors);
		}
		var returnValue = new GuidId(id);
		result.WithValue(returnValue);
		return result;
	}

	public static Result<GuidId> Create(string? id)
	{
		if (Guid.TryParse(id, out var guidId))
		{
			return Create(guidId);
		}
		Result<GuidId> result = new();
		result.WithError(ValidationMessages.InvalidField(DataDictionary.Id));
		return result;
	}
	public static Result<GuidId> Create(Guid? id, string propertyName)
	{
		Result<GuidId> result = new();
		//استفاه از گارد
		var guardResult = Guard.CheckIf(id, propertyName)
			.NotNull()
			.NotEmpty()
			.Length(FixLength);


		if (guardResult._result.IsFailed)
		{
			return result.WithErrors(guardResult._result.Errors);
		}
		var returnValue = new GuidId(id);
		result.WithValue(returnValue);
		return result;
	}

	public static Result<GuidId> Create(string? id, string propertyName)
	{
		if (Guid.TryParse(id, out var guidId))
		{
			return Create(guidId);
		}
		Result<GuidId> result = new();
		result.WithError(ValidationMessages.InvalidField(propertyName));
		return result;
	}
}

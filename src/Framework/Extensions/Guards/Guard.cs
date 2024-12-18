﻿using FluentResults;

using MDF.Framework.Extensions.ExtensionMethods;

namespace MDF.Framework.Extensions.Guards;
public static class Guard
{
	public static Guard<T> CheckIf<T>(T value, string propertyName)
	{
		return new Guard<T>(value, propertyName);
	}
}

public class Guard<T>
{
	internal T _value;
	internal string _propertyName;
	public readonly Result<T> _result;
	public List<IError> Errors => _result.Errors;
	public List<ISuccess> Successes => _result.Successes;
	public bool IsSuccess => _result.IsSuccess;
	public bool IsFailed => _result.IsFailed;
	public Guard(T value, string propertyName)
	{
		_value = value;
		_propertyName = propertyName;
		_result = Result.Ok();
		if (value is string str)
		{
			_value = (T)(object)str.Fix();
		}
		_result.WithValue(_value);
	}

	public void ThrowIfFailed()
	{
		if (_result.IsFailed)
		{
			var errorMessage = string.Join(", ", _result.Errors.Select(error => error.Message));
			throw new GuardException(errorMessage);
		}
	}
}

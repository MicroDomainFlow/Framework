
using MDF.Framework.Extensions.ExtensionMethods;

namespace MDF.Framework.Extensions.Results
{
	public class CustomResult : object
	{
		public CustomResult() : base()
		{
			_errors =
				new System.Collections.Generic.List<string>();

			_successes =
				new System.Collections.Generic.List<string>();
		}

		public bool IsFailed { get; set; }

		public bool IsSuccess { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		private readonly System.Collections.Generic.List<string> _errors;

		public System.Collections.Generic.IReadOnlyList<string> Errors
		{
			get
			{
				return _errors;
			}
		}

		[System.Text.Json.Serialization.JsonIgnore]
		private readonly System.Collections.Generic.List<string> _successes;

		public System.Collections.Generic.IReadOnlyList<string> Successes
		{
			get
			{
				return _successes;
			}
		}

		public void AddErrorMessage(string? message)
		{
			message =
				message.Fix();

			if (message == null)
			{
				return;
			}

			if (_errors.Contains(message))
			{
				return;
			}

			_errors.Add(message);
		}

		public void RemoveErrorMessage(string? message)
		{
			message =
				message.Fix();

			if (message == null)
			{
				return;
			}

			_errors.Remove(message);
		}

		public void ClearErrorMessages()
		{
			_errors.Clear();
		}

		public void AddSuccessMessage(string? message)
		{
			message =
				message.Fix();

			if (message == null)
			{
				return;
			}

			if (_successes.Contains(message))
			{
				return;
			}

			_successes.Add(message);
		}

		public void RemoveSuccessMessage(string? message)
		{
			message =
				message.Fix();

			if (message == null)
			{
				return;
			}

			_successes.Remove(message);
		}

		public void ClearSuccessMessages()
		{
			_successes.Clear();
		}
	}

	public class CustomResult<T> : CustomResult
	{
		public CustomResult() : base()
		{
		}

		public T Value { get; set; }
	}

	public static class ResultExtensions
	{
		static ResultExtensions()
		{
		}

		public static CustomResult ConvertToCustomResult(this FluentResults.Result result)
		{
			CustomResult customResult = new()
			{
				IsFailed = result.IsFailed,
				IsSuccess = result.IsSuccess,
			};

			if (result.Errors != null)
			{
				foreach (var item in result.Errors)
				{
					customResult.AddErrorMessage(message: item.Message);
				}
			}

			if (result.Successes != null)
			{
				foreach (var item in result.Successes)
				{
					customResult.AddSuccessMessage(message: item.Message);
				}
			}

			return customResult;
		}

		public static CustomResult<T> ConvertToCustomResult<T>(this FluentResults.Result<T> result)
		{
			CustomResult<T> customResult = new()
			{
				IsFailed = result.IsFailed,
				IsSuccess = result.IsSuccess,
			};

			if (result.IsFailed == false)
			{
				customResult.Value = result.Value;
			}

			if (result.Errors != null)
			{
				foreach (var item in result.Errors)
				{
					customResult.AddErrorMessage(message: item.Message);
				}
			}

			if (result.Successes != null)
			{
				foreach (var item in result.Successes)
				{
					customResult.AddSuccessMessage(message: item.Message);
				}
			}

			return customResult;
		}
	}
}


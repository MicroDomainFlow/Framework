namespace Framework.Extensions.Guards;
public class GuardException : Exception
{
	public GuardException()
	{
	}

	public GuardException(string message)
		: base(message)
	{
	}

	public GuardException(string message, Exception inner)
		: base(message, inner)
	{
	}
}

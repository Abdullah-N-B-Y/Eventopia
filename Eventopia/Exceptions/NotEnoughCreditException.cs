using System;

namespace Eventopia.API.Exceptions
{
	public class NotEnoughCreditException : Exception
	{
		public NotEnoughCreditException() : base("Not enough credit.")
		{

		}

		public NotEnoughCreditException(string message) : base(message)
		{
		}

		public NotEnoughCreditException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class ValidateException : Exception
{
	public ValidateException(string message) : base(message)
	{

	}

	public ValidateException() : this("Not validate")
	{

	}

	public ValidateException(Exception ex) : this(ex.Message) 
	{

	}
}

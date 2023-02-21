using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Wrappers;

public class ServiceResponse<T>
{
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Value { get; set; }
	public ServiceResponse(T value)
	{
		Value = value;
	}

	public ServiceResponse()
	{

	}
}

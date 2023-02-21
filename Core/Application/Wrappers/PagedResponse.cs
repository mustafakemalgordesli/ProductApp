using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers;

public class PagedResponse<T> : ServiceResponse<T> 
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PagedResponse(T value) : base(value)
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PagedResponse(T value, int pageNumber, int pageSize) : base(value) 
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PagedResponse(T value, int pageNumber) : base(value)
    {
        PageNumber = pageNumber;
        PageSize = 10;
    }
}

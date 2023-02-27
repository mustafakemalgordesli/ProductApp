using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<bool>
{
    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}

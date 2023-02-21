using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<bool>
{
	public DeleteProductCommand(int id)
	{
		Id = id;
	}
    public int Id { get; set; }
}

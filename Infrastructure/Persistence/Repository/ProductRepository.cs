using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository;

public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
{
	public ProductRepository(ApplicationDbContext dbContext): base(dbContext)
	{
	}

    public async override Task<List<Product>> GetAllAsync()
    {
        return await dbContext.Set<Product>().Include(p => p.Category).ToListAsync();
    }

    public override  async Task<Product> GetByIdAsync(int id)
    {
        return await dbContext.Set<Product>().Include(x=> x.Category).SingleOrDefaultAsync(p => p.Id == id);
    }
}

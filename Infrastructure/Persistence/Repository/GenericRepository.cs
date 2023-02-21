using Application.Interfaces.Repository;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual List<T> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>()
                .Where(expression).AsNoTracking().ToList();
        }

        public void Update(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }
    }
}

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
    public class GenericRepository<T> : GenericRepositoryAsync<T>, IGenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
        }

        public virtual List<T> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>()
                .Where(expression).AsNoTracking().ToList();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}

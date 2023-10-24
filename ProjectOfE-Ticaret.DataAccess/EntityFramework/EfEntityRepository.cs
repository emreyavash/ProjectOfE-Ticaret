using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOfE_Ticaret.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        private readonly ILogger<EfEntityRepository<TEntity, TContext>> _logger;

        public EfEntityRepository(ILogger<EfEntityRepository<TEntity, TContext>> logger)
        {
            _logger = logger;
        }

        public bool Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);

                addedEntity.State = EntityState.Added;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex.ToString());
                    return false;
                }

            }
        }

        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex.ToString());

                    return false;
                }
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex.ToString());

                    return false;
                }
            }
        }
    }
}

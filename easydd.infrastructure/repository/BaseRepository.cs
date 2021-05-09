using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using easydd.core.interfaces;
using easydd.core.model;
using easydd.infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace easydd.infrastructure.repository
{
    public class BaseRepository<TModelType> : IRepository<TModelType> where TModelType : Entity, new()
    {
        private EasyContext context;
        protected DbSet<TModelType> DbSet { get; set; }

        public BaseRepository(EasyContext context)
        {
            this.context = context;
            DbSet = this.context.Set<TModelType>();
        }

        public virtual IQueryable<TModelType> Collection()
        {
            return DbSet.AsQueryable();
        }

        public virtual async Task<TModelType> Single(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (null != entity)
            {
                DbSet.Remove(entity);
                await SaveChanges();
            }

            return null != entity;
        }

        public virtual async Task<TModelType> Update(TModelType model)
        {
            DbSet.Update(model);
            await SaveChanges();
            return model;
        }

        public virtual async Task<TModelType> Create(TModelType model)
        {
            DbSet.Add(model);
            await SaveChanges();
            return model;
        }

        protected async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}

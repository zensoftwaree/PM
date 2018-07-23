using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DomainApp
{
    public interface IGlobalRepo<TEntity> : IQueryable<TEntity>
    {
        void AddItem(TEntity item);
        void UpdateItem(TEntity item);
        


    }

    public class GlobalRepo<TEntity> : IGlobalRepo<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        public Type ElementType
        {
            get
            {
                return typeof(TEntity);
            }
        }

        public Expression Expression
        {
            get
            {
                return _dbSet.
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                _dbSet.P
            }
        }

        public IQueryable<TEntity> Query {
            get 
            {
                return (IQueryable<TEntity>)_dbSet; 
            }
            
                    }

        public GlobalRepo(DbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _dbSet = context.Set<TEntity>();
            
        }

        
        
        public void AddItem(TEntity item)
        {
        }

        public void UpdateItem(TEntity item)
        {
        }

    }
}

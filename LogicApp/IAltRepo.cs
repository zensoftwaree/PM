using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public interface IAltRepo<T> : IUnitOfWork
    {
        IQueryable<T> GetAllItems();
        IQueryable<T> GetAllWith(string includes);
        void AddItem(T entity);
        void RemoveItem(T entity);
        void UpdateItem(T entity);
    }

    public interface IUnitOfWork
    {
        void Save();
    }
}

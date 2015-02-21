using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();
        IQueryable<T> AllWithProperties(List<Expression<Func<T, object>>> _includeProperties);

        T Find(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> _includeProperties);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> _includeProperties);


        T Create(T t);
        void Delete(T t);
        void Delete(Expression<Func<T, bool>> predicate);
        void Update(T t);
        int Count { get; }
    }
}

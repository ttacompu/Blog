using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BlogData.Repository
{
    public class Repository<TObject> : IRepository<TObject> where TObject : class
    {
        protected DataContext Context;
        private bool IsShareContext = false;

        public Repository(DataContext _context)
        {
            this.Context = _context;
            IsShareContext = true;
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return Context.Set<TObject>();
            }
        }

        public IQueryable<TObject> All()
        {
            return DbSet.AsQueryable();
        }

        public TObject Create(TObject t)
        {
            var newEntry = DbSet.Add(t);
            if (!IsShareContext)
                Context.SaveChanges();
            return newEntry;
        }

        public TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public TObject Find(Expression<Func<TObject, bool>> predicate, List<Expression<Func<TObject, object>>> _includeProperties)
        {
            _includeProperties.ForEach(x => DbSet.Include(x));
            return DbSet.SingleOrDefault(predicate);
        }

        public IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate, List<Expression<Func<TObject, object>>> _includeProperties)
        {
            _includeProperties.ForEach(x => DbSet.Include(x));
            return DbSet.Where(predicate);
        }

        public void Delete(TObject t)
        {
            DbSet.Attach(t);
            DbSet.Remove(t);

            if (!IsShareContext)
                Context.SaveChanges();
        }

        public void Delete(Expression<Func<TObject, bool>> predicate)
        {
            var objects = Filter(predicate);

            foreach (var myobject in objects)
                DbSet.Remove(myobject);

            if (!IsShareContext)
                Context.SaveChanges();
        }

        public void Update(TObject t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State =  EntityState.Modified;
            if (!IsShareContext)
                Context.SaveChanges();
        }

        public int Count
        {
            get { return DbSet.Count(); }
        }

        public void Dispose()
        {
            if (IsShareContext && (Context != null))
            {
                Context.Dispose();
            }
        }

        public IQueryable<TObject> AllWithProperties(List<Expression<Func<TObject, object>>> _includeProperties)
        {
            _includeProperties.ForEach(x => DbSet.Include(x));
            return DbSet.AsQueryable();
        }
    }
}
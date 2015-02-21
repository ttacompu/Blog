using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogData.Repository;

namespace BlogData
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }

    public interface IDALContext : IUnitOfWork
    {
        IPostRepository PostRepository { get; }
    }

    public class DALContext : IDALContext
    {
        private DataContext dbContext;
        private IPostRepository _posts;
        

        public DALContext()
        {
            dbContext = new DataContext();
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (_posts == null)
                    _posts = new PostRepository(dbContext);
                return _posts;
            }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_posts != null)
                _posts.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
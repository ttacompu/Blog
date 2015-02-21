using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogData;
using BlogData.Repository;
using BlogDataModel;

namespace BlogServices
{
    public interface IBlogService
    {
        IList<Post> GetPostWithPage(int pageno, int pagesize);
        int TotalPosts();

    }

    public class BlogService : IBlogService
    {
        private IDALContext _UnitOfWork;

        public BlogService(IDALContext dalcontext)
        {
            _UnitOfWork = dalcontext;
        }
        public IList<Post> GetPostWithPage(int pageno, int pagesize)
        {
            var propertiesToLoad = new List<Expression<Func<Post, object>>>();
            // Eager loading
            propertiesToLoad.Add(x => x.Category);
            propertiesToLoad.Add(x => x.Tags);
            return _UnitOfWork.PostRepository.Filter(x => x.Published, propertiesToLoad).OrderByDescending(p => p.PostedOn).Skip(pageno * pagesize).Take(pagesize).ToList();
        }

        public int TotalPosts()
        {
            return _UnitOfWork.PostRepository.Filter(x => x.Published).Count();
        }
    }
}

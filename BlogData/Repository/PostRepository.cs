using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDataModel;

namespace BlogData.Repository
{
    public interface IPostRepository : IRepository<Post>
    {

    }
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DataContext context)
            : base(context)
        {
        }
    }
}

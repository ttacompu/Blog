using System.Web.Mvc;
using BlogServices;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        private readonly IBlogService _blogservice;

        public BlogController(IBlogService blogservice)
        {
            _blogservice = blogservice;
        }
        public ViewResult Posts(int p = 1)
        {
            PostListViewModel model = new PostListViewModel()
            {
                Posts = _blogservice.GetPostWithPage(p - 1, 3),
                TotalPosts = _blogservice.TotalPosts()
            };
            return View(model);
        }

    }
}

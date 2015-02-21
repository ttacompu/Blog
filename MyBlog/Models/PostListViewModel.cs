using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogDataModel;

namespace MyBlog.Models
{
    public class PostListViewModel
    {
        public IList<Post> Posts { get;  set; }
        public int TotalPosts { get;  set; }
        public string CurrentCategory { get; set; }
        public IList<string> Categories { get; set; }

    }
}
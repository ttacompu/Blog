using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDataModel
{
    public class Category : IAuditInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public IList<Post> Posts { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

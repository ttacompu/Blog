using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDataModel
{
    public class Post : IAuditInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Meta { get; set; }

        public string UrlSlug { get; set; }

        public bool IsImageInclude { get; set; }
        public string ImageLink { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual Category Category { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}

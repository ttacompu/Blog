using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using BlogDataModel;

namespace BlogData
{
    public class PostDataConfiguration : EntityTypeConfiguration<Post>
    {
        public PostDataConfiguration()
        {
            this.Property(p => p.Title).IsRequired().HasMaxLength(100);
            this.Property(p => p.ShortDescription).IsOptional().HasMaxLength(500);
            this.Property(p => p.Description).IsRequired().HasColumnType("nvarchar(max)");
            this.Property(p => p.Meta).IsRequired().HasMaxLength(100);
            this.Property(p => p.UrlSlug).IsRequired().HasMaxLength(100);
            this.Property(p => p.Published).IsRequired().HasColumnType("bit");
            this.Property(p => p.ImageLink).IsOptional().HasMaxLength(100);
            this.Property(p => p.PostedOn).IsRequired().HasColumnType("datetime");
        }
    }
}

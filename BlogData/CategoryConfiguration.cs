using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDataModel;

namespace BlogData
{
    public class CategoryConfiguration: EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.Property(p => p.Name).IsRequired().HasMaxLength(100);
            this.Property(p => p.UrlSlug).IsRequired().HasMaxLength(100);
            this.Property(p => p.Description).IsRequired().HasColumnType("nvarchar(max)");
        }
    }
}

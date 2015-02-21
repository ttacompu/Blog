using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDataModel;

namespace BlogData
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConntection";
            }
        }

        public DataContext()
            : base(nameOrConnectionString: DataContext.ConnectionStringName)
        {
        }
        static DataContext()
        {
            Database.SetInitializer(new BlogDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostDataConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Entity<Post>().HasRequired(c => c.Category).WithMany(p => p.Posts);
            modelBuilder.Entity<Post>().HasMany(p => p.Tags).WithMany(t => t.Posts).Map(x => x.MapLeftKey("PostId").MapRightKey("TagId").ToTable("PostTag"));

        }

        private void ApplyRules()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(x => x.Entity is IAuditInfo && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.CreatedOn = DateTime.Now;
                }
                e.ModifiedOn = DateTime.Now;

            }
        }

        public override int SaveChanges()
        {
            this.ApplyRules();
            return base.SaveChanges();
        }


    }
}

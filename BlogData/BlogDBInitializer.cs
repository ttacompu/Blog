using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;
using BlogDataModel;

namespace BlogData
{
    public class BlogDBInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Category mycategory = new Category()
            {
                 Name = "Jason",
                  UrlSlug = "What's up",
                   Description = "All about Jason"
            };

            Post newpost = new Post()
            {
                 Category = mycategory,
                  Meta = "what is meta",
                   Published = true,
                     ShortDescription= "This blog is about Jason. That time, he was one year old and very curious.",
                      Title = "Jason in Central Park",
                       PostedOn= DateTime.Now,
                        UrlSlug = "What's up",
                         Description = "This is about Jason, my son. When he was one year old, we visited to central park. He was so happy. We visited to central's park zoo. He like dancing dolls at entrance of zoo. We saw snow leopart, variety of birds and snake. I took a shot of his photo.  ",
                         ImageLink="/Images/jason1year.gif",
                         IsImageInclude = true
            };

            var postlist = new List<Post>();
            postlist.Add(newpost);

            Tag newtag = new Tag(){
                 Posts = postlist,
                  Name = "Jason Tag",
                   Description = "Jason experience",
                    UrlSlug = "Jason Jason Jason",
            };

            Category secondCat = new Category()
            {
                Name = "Hummar",
                UrlSlug = "What's going on",
                Description = "About Joke"
            };

            Post secondpost = new Post()
            {
                Category = secondCat,
                Meta = "data about your object",
                Published = true,
                ShortDescription = "second blog second blog",
                Title = "my second blog",
                PostedOn = DateTime.Now,
                UrlSlug = "Efficient used Url Slug",
                Description = "about my second data",
                IsImageInclude = false
            };

            var secondpostList = new List<Post>();
            secondpostList.Add(secondpost);

            Tag secondtag = new Tag()
            {
                Posts = secondpostList,
                Name = "Funny",
                Description = "What is funny",
                UrlSlug = "HAHA",
            };

            Category ThirdCat = new Category()
            {
                Name = "Burmese",
                UrlSlug = "Language",
                Description = "About burmese Language"
            };

            Post thirdpost = new Post()
            {
                Category = ThirdCat,
                Meta = "data about your object",
                Published = true,
                ShortDescription = "third blog thid blog",
                Title = "my third blog",
                PostedOn = DateTime.Now,
                UrlSlug = "Efficient used Url Slug",
                Description = "about my third data",
                IsImageInclude = false
            };

            var thirdpostList = new List<Post>();
            thirdpostList.Add(thirdpost);

            Tag thirdtag = new Tag()
            {
                Posts = thirdpostList,
                Name = "Burmese",
                Description = "I am trying to write in burmese",
                UrlSlug = "Language Skills",
            };

            Category FourthCat = new Category()
            {
                Name = "C#",
                UrlSlug = "C# Language",
                Description = "About C# Language"
            };

            Post fourthpost = new Post()
            {
                Category = FourthCat,
                Meta = "c# meta data",
                Published = true,
                ShortDescription = "Fourth blog Fourth blog",
                Title = "my Fourth blog",
                PostedOn = DateTime.Now,
                UrlSlug = "Efficient used Url Slug",
                Description = "about my fourth data",
                IsImageInclude = false
            };

            var fouthpostList = new List<Post>();
            fouthpostList.Add(fourthpost);

            Tag fourthtag = new Tag()
            {
                Posts = fouthpostList,
                Name = "C#",
                Description = "C# Language Again",
                UrlSlug = "c# Language Skills",
            };


            context.Tags.Add(newtag);
            context.Tags.Add(secondtag);
            context.Tags.Add(thirdtag);
            context.Tags.Add(fourthtag);
            base.Seed(context);
        }
    }
}

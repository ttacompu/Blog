using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogData;

namespace BlogConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  Console.WriteLine("Initializing Database ...");
            DataContext context = new DataContext();
            context.Database.Initialize(true);

            Console.WriteLine("Done...");
            Console.Read();*/

            DALContext context = new DALContext();

            foreach (var mypost in context.PostRepository.All())
            {
                Console.WriteLine(mypost.Description);
            }

            Console.Read();
        }
    }
}

using RowLevelSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowLevelSecurity
{
    class Program
    {
        public static int UserId = 3; //fake userId
        static void Main(string[] args)
        {
            GenericRepository<Post, Context> repo = new GenericRepository<Post, Context>();

            //add
            Post post = new Post();
            post.Context = "p 5";
            repo.Add(post);
            repo.Commit();


            //get all 
            List<Post> posts = repo.GetAll().ToList();

            foreach (Post item in posts)
                Console.WriteLine(item.Context);

            Console.ReadKey();

           
            //get customize 
            List<Post> customizeList = repo.CustomizeGet(a => a.UserId == 3).ToList();

            foreach (Post item in customizeList)
                Console.WriteLine(item.Context);

            Console.ReadKey();
        }
    }
}


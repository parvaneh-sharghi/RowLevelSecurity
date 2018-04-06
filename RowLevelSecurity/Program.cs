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
        public static int UserId = 1; //fake userId
        static void Main(string[] args)
        {

            GenericRepository<Post, Context> repo = new GenericRepository<Post, Context>();

            List<Post> posts = repo.GetAll().ToList();

            foreach (Post item in posts)
                Console.WriteLine(item.Context);

            Console.ReadKey();
        }
    }
} 


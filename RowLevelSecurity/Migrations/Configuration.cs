namespace RowLevelSecurity.Migrations
{
    using RowLevelSecurity.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context context)
        {
            context.Users.AddOrUpdate(x => x.Id,
              new User { Id = 1, Name = "p", Age = 30, Type = User.UserType.Admin },
              new User { Id = 2, Name = "s", Age = 20, Type = User.UserType.Ordinary },
              new User { Id = 3, Name = "m", Age = 25, Type = User.UserType.Ordinary }
            );

            context.Posts.AddOrUpdate(x => x.Id,
                new Post { Context = "p 1", UserId = 3 },
                new Post { Context = "s 1", UserId = 2 },
                new Post { Context = "s 2", UserId = 2 },
                new Post { Context = "m 1", UserId = 1 },
                new Post { Context = "s 3", UserId = 2 },
                new Post { Context = "p 2", UserId = 3 },
                new Post { Context = "p 3", UserId = 3 }
            );

            context.SaveChanges();
        }
    }
}

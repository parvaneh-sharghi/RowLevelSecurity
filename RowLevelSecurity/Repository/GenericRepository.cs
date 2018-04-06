using RowLevelSecurity.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace RowLevelSecurity
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> CustomizeGet(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        IQueryable<T> GetAll();
    }
    public class GenericRepository<TEntity, DbContext> : IGenericRepository<TEntity> where TEntity : class, new() where DbContext : Models.Context, new()
    {
        private DbContext entities = new DbContext();

        public void Add(TEntity entity)
        {
            int userId = Program.UserId; // یوزد آی دی بصورت فیک ساخته شده
                                         // اگر از آیدنتیتی استفاده میکنید میتوان آی دی و هر چیز دیگری که کلیم شده را در اختیار گرفت
            if (typeof(IUser).IsAssignableFrom(typeof(TEntity)))
            {
                ((IUser)entity).UserId = userId;
            }
            entities.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> CustomizeGet(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = entities.Set<TEntity>().Where(predicate);
            return query;
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> result = entities.Set<TEntity>();

            int userId = Program.UserId; // یوزد آی دی بصورت فیک ساخته شده
                                         // اگر از آیدنتیتی استفاده میکنید میتوان آی دی و هر چیز دیگری که کلیم شده را در اختیار گرفت

            if (typeof(IUser).IsAssignableFrom(typeof(TEntity)))
            {
                User me = entities.Users.Single(c => c.Id == userId);
                if (me.Type == User.UserType.Admin)
                {
                    return result;
                }
                else if (me.Type == User.UserType.Ordinary)
                {
                    string query = $"{nameof(IUser.UserId).ToString()}={userId}";

                    return result.Where(query);
                }
            }
            return result;
        }

        public void Commit()
        {
            entities.SaveChanges();
        }
    }
}

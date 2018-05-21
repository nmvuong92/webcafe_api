using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace VD.Data.Base
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FullTextSearch(Expression<Func<T, bool>> where = null, Expression<Func<T, object>> expression = null, string searchKey = "");
        IQueryable<T> ContainsSearch(Expression<Func<T, bool>> where = null, Expression<Func<T, object>> expression = null, string searchKey = "");
        IQueryable<T> GetList(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        /// <summary>
        /// CRUD METHOD
        /// </summary>
        /// <param name="item"></param>
        T GetEntry(int id);
        T Insert(T item);
        void Update(T item);
        void Delete(T entityToDelete);
        void Delete(int id);
        void Delete(Expression<Func<T, bool>> where);

        void Truncate(string tableName = "");
        void QuerySQL(string sql = "");

        void Save();
        int Count(Expression<Func<T, bool>> where = null);

        T FirstOrDefault(Expression<Func<T, bool>> where=null);
        T SingleOrDefault(Expression<Func<T, bool>> where = null);
    }
}

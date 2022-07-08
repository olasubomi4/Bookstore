using System;
using System.Linq.Expressions;

namespace rock.DataAccess.IRepository
{
	public interface IRepository<T> where T : class
	{

	
		T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

        IEnumerable<T> GetAll(string? includeProperties = null);

        void Remove(T entity);

        void Add(T entity);

		void RemoveRange(IEnumerable<T> entity);

    }
}

